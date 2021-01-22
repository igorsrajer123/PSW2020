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
    public class DoctorAdapter
    {
        [Fact]
        public void Doctor_to_doctor_dto()
        {
            Doctor doctor = CreateDoctor();

            DoctorDto myDoctor = HospitalApp.Adapters.DoctorAdapter.DoctorToDoctorDto(doctor);

            myDoctor.ShouldBeOfType(typeof(DoctorDto));
        }

        [Fact]
        public void Doctor_dto_to_doctor()
        {
            DoctorDto doctorDto = CreateDoctorDto();

            Doctor myDoctor = HospitalApp.Adapters.DoctorAdapter.DoctorDtoToDoctor(doctorDto);

            myDoctor.ShouldBeOfType(typeof(Doctor));
        }

        #region "Helper functions"
        private DoctorDto CreateDoctorDto()
        {
            return new DoctorDto
            {
                Id = 1,
                Address = "Adresa",
                FirstName = "Prvo ime",
                LastName = "Poslednje ime",
                IsMalicious = false,
                IsBlocked = false,
                PhoneNumber = "123",
                Role = "Doctor",
                Type = DoctorType.GeneralPractitioner,
                Username = "user",
                WorkingDays = null
            };
        }

        private Doctor CreateDoctor()
        {
            return new Doctor
            {
                Id = 1,
                Address = "Adresa",
                FirstName = "Prvo ime",
                LastName = "Poslednje ime",
                IsMalicious = false,
                IsBlocked = false,
                PhoneNumber = "123",
                Role = "Doctor",
                Type = DoctorType.GeneralPractitioner,
                Username = "user",
                WorkingDays = null
            };
        }
        #endregion
    }
}
