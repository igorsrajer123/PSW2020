using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class AppointmentAdapter
    {
        public static Appointment AppointmentDtoToAppointment(AppointmentDto appointmentDto)
        {
            Appointment appointment = new Appointment
            {
                Id = appointmentDto.Id,
                Date = appointmentDto.Date,
                DoctorId = appointmentDto.DoctorId,
                Time = appointmentDto.Time,
                IsCancelled = appointmentDto.IsCancelled,
                IsDone = appointmentDto.IsDone,
                PatientId = appointmentDto.PatientId
            };

            return appointment;
        }

        public static AppointmentDto AppointmentToAppointmentDto(Appointment appointment)
        {
            AppointmentDto appointmentDto = new AppointmentDto
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Time = appointment.Time,
                IsDone = appointment.IsDone,
                IsCancelled = appointment.IsCancelled,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId
            };

            return appointmentDto;
        }
    }
}
