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

            if(appointment == null || doctor == null)
                return null;

            appointment.Status = AppointmentStatus.Cancelled;
            string appointmentFullDate = appointment.Date + " " + appointment.Time;
            doctor.WorkingDays.ToList().Add(appointmentFullDate);
            doctor.WorkingDays = doctor.WorkingDays.ToArray();

            _dbContext.SaveChanges();

            return AppointmentAdapter.AppointmentToAppointmentDto(appointment);
        }
    }
}
