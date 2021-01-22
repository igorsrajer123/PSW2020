using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.AdaptersTests
{
    public class AppointmentAdapter
    {
        [Fact]
        public void Appointment_to_appointment_dto()
        {
            Appointment appointment = CreateAppointment();

            AppointmentDto myAppointment = HospitalApp.Adapters.AppointmentAdapter.AppointmentToAppointmentDto(appointment);

            myAppointment.ShouldBeOfType(typeof(AppointmentDto));
        }

        [Fact]
        public void Appointment_dto_to_appointment()
        {
            AppointmentDto appointmentDto = CreateAppointmentDto();

            Appointment myAppointment = HospitalApp.Adapters.AppointmentAdapter.AppointmentDtoToAppointment(appointmentDto);

            myAppointment.ShouldBeOfType(typeof(Appointment));
        }

        #region "Helper functions"
        private Appointment CreateAppointment()
        {
            return new Appointment
            {
                Id = 1,
                Date = "!@#",
                DoctorId = 1,
                PatientId = 2,
                Time = "1:45PM",
                CancellationDate = "",
                Status = AppointmentStatus.Active
            };
        }

        private AppointmentDto CreateAppointmentDto()
        {
            return new AppointmentDto
            {
                Id = 1,
                Date = "2021-05-01",
                DoctorId = 1,
                PatientId = 2,
                Time = "1:45PM",
                CancellationDate = "",
                Status = AppointmentStatus.Active
            };
        }
        #endregion
    }
}
