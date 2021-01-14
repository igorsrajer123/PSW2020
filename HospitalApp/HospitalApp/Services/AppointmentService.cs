using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private MyDbContext _dbContext;
        private IReferralService _referralService;

        public AppointmentService(MyDbContext context, IReferralService referralService)
        {
            _dbContext = context;
            _referralService = referralService;
        }

        public List<AppointmentDto> GetAll()
        {
            List<AppointmentDto> myAppointments = new List<AppointmentDto>();

            _dbContext.Appointments.ToList().ForEach(appointment => myAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDto(appointment)));

            return myAppointments;
        }

        public AppointmentDto GetById(int appointmentId)
        {
            Appointment appointment = _dbContext.Appointments.SingleOrDefault(a => a.Id == appointmentId);

            if (appointment == null) return null;

            return AppointmentAdapter.AppointmentToAppointmentDto(appointment);
        }

        public AppointmentDto Add(AppointmentDto appointmentDto)
        {
            if (appointmentDto == null) return null;

            Appointment myAppointment = AppointmentAdapter.AppointmentDtoToAppointment(appointmentDto);
            myAppointment.Status = AppointmentStatus.Active;
            _dbContext.Patients.SingleOrDefault(patient => patient.Id == myAppointment.PatientId).Appointments.Add(myAppointment);
            _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == myAppointment.DoctorId).Appointments.Add(myAppointment);

            RemoveDoctorsActiveAppointmentDate(_dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == myAppointment.DoctorId), myAppointment);
            _dbContext.Appointments.Add(myAppointment);
            _dbContext.SaveChanges();

            return appointmentDto;
        }

        public List<AppointmentDto> GetPatientAppointments(int patientId)
        {
            Patient myPatient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (myPatient == null) return null;

            return myPatient.Appointments.Select(appointment => new AppointmentDto() 
            { 
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                Date = appointment.Date,
                Time = appointment.Time,
                PatientId = appointment.PatientId,
                Status = appointment.Status,
                CancellationDate = appointment.CancellationDate
            }).ToList();
        }

        public List<AppointmentDto> GetDoctorAppointments(int doctorId)
        {
            Doctor myDoctor = _dbContext.Doctors.FirstOrDefault(doctor => doctor.Id == doctorId);

            if (myDoctor == null) return null;

            return myDoctor.Appointments.Select(appointment => new AppointmentDto()
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                Date = appointment.Date,
                Time = appointment.Time,
                PatientId = appointment.PatientId,
                Status = appointment.Status,
                CancellationDate = appointment.CancellationDate
            }).ToList();
        }

        public AppointmentDto CancelAppointment(int appointmentId)
        {
            Appointment myAppointment = _dbContext.Appointments.SingleOrDefault(appointment => appointment.Id == appointmentId);
            PatientsCancelledAppointmentsAdded(myAppointment);

            if (myAppointment == null || (GetAppointmentFullDate(myAppointment) - DateTime.Now).TotalDays < 2)
                return null;

            myAppointment.Status = AppointmentStatus.Cancelled;
            myAppointment.CancellationDate = DateTime.Today.ToString("yyyy-MM-dd");
            ReturnDoctorsCancelledDate(_dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == myAppointment.DoctorId), myAppointment);

            return AppointmentAdapter.AppointmentToAppointmentDto(myAppointment);
        }

        public void PatientsCancelledAppointmentsAdded(Appointment appointment)
        {
            _dbContext.Patients.SingleOrDefault(patient => patient.Id == appointment.PatientId).CancelledAppointments++;
            CheckIfMaliciousPatient(_dbContext.Patients.SingleOrDefault(patient => patient.Id == appointment.PatientId));
        }

        public void ReturnDoctorsCancelledDate(Doctor doctor, Appointment appointment)
        {
            List<string> myDates = doctor.WorkingDays.ToList();
            myDates.Add(GetAppointmentFullDateString(appointment));
            doctor.WorkingDays = myDates.ToArray();

            _dbContext.SaveChanges();
        }

        public void RemoveDoctorsActiveAppointmentDate(Doctor doctor, Appointment appointment)
        {
            string myDate = doctor.WorkingDays.FirstOrDefault(d => d.Replace(" ", string.Empty) == GetAppointmentFullDateString(appointment).Replace(" ", string.Empty));
            doctor.WorkingDays = doctor.WorkingDays.Where(w => w != myDate).ToArray();
            doctor.Appointments.Add(appointment);
        }

        public void CheckIfMaliciousPatient(Patient patient)
        {  
            if (patient.CancelledAppointments >= 3)
                CheckLastThreeCancelledAppointments(GetPatientAppointments(patient.Id), patient);
        }     
        
        public void CheckLastThreeCancelledAppointments(List<AppointmentDto> cancelledAppointments, Patient patient)
        {
            List<AppointmentDto> lastThree = cancelledAppointments.Skip(Math.Max(0, cancelledAppointments.Count() - 3)).ToList();

            if ((Convert.ToDateTime(lastThree.Last().CancellationDate) - Convert.ToDateTime(lastThree.First().CancellationDate)).TotalDays < 30)
                patient.IsMalicious = true;
        }

        //appointment is set to "Done" when it's date expires
        public AppointmentDto SetAppointmentDone(int appointmentId)
        {
            Appointment myAppointment = _dbContext.Appointments.SingleOrDefault(appointment => appointment.Id == appointmentId);

            if (myAppointment == null) return null;

            if(DateTime.Parse(GetAppointmentFullDateString(myAppointment)) < DateTime.Today && myAppointment.Status != AppointmentStatus.Cancelled)
            {
                SetAppointmentsReferralDeleted(myAppointment);
                myAppointment.Status = AppointmentStatus.Done;
                _dbContext.SaveChanges();
            }

            return AppointmentAdapter.AppointmentToAppointmentDto(myAppointment);
        }

        //doctor can set appointment to "Done"
        public AppointmentDto FinishAppointment(int appointmentId)
        {
            Appointment myAppointment = _dbContext.Appointments.SingleOrDefault(appointment => appointment.Id == appointmentId);

            if (myAppointment == null) return null;

            SetAppointmentsReferralDeleted(myAppointment);
            myAppointment.Status = AppointmentStatus.Done;
            _dbContext.SaveChanges();
        
            return AppointmentAdapter.AppointmentToAppointmentDto(myAppointment);
        }

        public DateTime GetAppointmentFullDate(Appointment appointment)
        {
            return DateTime.Parse(GetAppointmentFullDateString(appointment));
        }

        public string GetAppointmentFullDateString(Appointment appointment)
        {
            return appointment.Date + " " + appointment.Time;
        }

        public void SetAppointmentsReferralDeleted(Appointment appointment)
        {
            if (_referralService.GetAppointmentsReferral(appointment) != null)
            {
                Referral referal1 = ReferralAdapter.ReferralDtoToReferral(_referralService.GetAppointmentsReferral(appointment));
                Referral referal2 = _dbContext.Referrals.SingleOrDefault(referral => referral.Id == referal1.Id);
                referal2.IsDeleted = true;
                _dbContext.SaveChanges();
            }
                
        }
    }
}
