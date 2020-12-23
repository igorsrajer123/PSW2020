using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private MyDbContext _dbContext;

        public AppointmentService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<AppointmentDto> GetAll()
        {
            List<AppointmentDto> myAppointments = new List<AppointmentDto>();

            _dbContext.Appointments.ToList().ForEach(a => myAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDto(a)));

            return myAppointments;
        }

        public AppointmentDto Add(AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
                return null;

            Appointment appointment = AppointmentAdapter.AppointmentDtoToAppointment(appointmentDto);
            Patient patient = _dbContext.Patients.SingleOrDefault(p => p.Id == appointment.PatientId);
            Doctor doctor = _dbContext.Doctors.SingleOrDefault(d => d.Id == appointment.DoctorId);
            appointment.Status = AppointmentStatus.Active;

            if (patient == null || doctor == null)
                return null;

            string appointmentFullDate = appointmentDto.Date + " " + appointmentDto.Time;

            string myDate = doctor.WorkingDays.SingleOrDefault(d => d.Replace(" ", string.Empty) == appointmentFullDate.Replace(" ", string.Empty));
            doctor.WorkingDays = doctor.WorkingDays.Where(w => w != myDate).ToArray();
           
            patient.Appointments.Add(appointment);
            doctor.Appointments.Add(appointment);

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();

            return appointmentDto;
        }

        public List<AppointmentDto> GetPatientAppointments(int patientId)
        {
            Patient patient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (patient == null || patient.Appointments == null)
                return null;

            return patient.Appointments.Select(a => new AppointmentDto() { Id = a.Id,
                                                                           DoctorId = a.DoctorId,
                                                                           Date = a.Date,
                                                                           Time = a.Time,
                                                                           PatientId = a.PatientId,
                                                                           Status = a.Status }).ToList();
        }

        public AppointmentDto CancelAppointment(int appointmentId)
        {
            Appointment appointment = _dbContext.Appointments.SingleOrDefault(a => a.Id == appointmentId);
            Doctor doctor = _dbContext.Doctors.SingleOrDefault( d => d.Id == appointment.DoctorId);

            string appointmentFullDate = appointment.Date + " " + appointment.Time;
            DateTime dt = DateTime.Parse(appointmentFullDate);
            if (appointment == null || doctor == null || (dt - DateTime.Now).TotalDays < 2)
                return null;

            appointment.Status = AppointmentStatus.Cancelled;
            List<string> myDates = doctor.WorkingDays.ToList();
            myDates.Add(appointmentFullDate);
            doctor.WorkingDays = myDates.ToArray();

            _dbContext.SaveChanges();

            return AppointmentAdapter.AppointmentToAppointmentDto(appointment);
        }

        public AppointmentDto AppointmentDone(int appointmentId)
        {
            Appointment appointment = _dbContext.Appointments.SingleOrDefault(a => a.Id == appointmentId);

            if (appointment == null)
                return null;

            Patient patient = appointment.Patient;
            Referral referral = _dbContext.Referrals.SingleOrDefault(r => r.PatientId == patient.Id && r.SpecialistId == appointment.DoctorId);

            string appointmentFullDate = appointment.Date + " " + appointment.Time;
            DateTime dt = DateTime.Parse(appointmentFullDate);

            if(dt < DateTime.Today)
            {
                if(referral != null)
                    referral.IsDeleted = true;

                appointment.Status = AppointmentStatus.Done;
            }

            _dbContext.SaveChanges();

            return AppointmentAdapter.AppointmentToAppointmentDto(appointment);
        }
    }
}
