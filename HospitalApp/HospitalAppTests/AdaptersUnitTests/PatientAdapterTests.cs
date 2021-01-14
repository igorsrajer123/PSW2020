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
    public class PatientAdapterTests
    {
        [Fact]
        private void Patient_to_patient_dto()
        {
            Patient patient = CreatePatient();

            PatientDto myPatient = PatientAdapter.PatientToPatientDto(patient);

            myPatient.ShouldBeOfType(typeof(PatientDto));
        }

        [Fact]
        private void Patient_dto_to_patient()
        {
            PatientDto patient = CreatePatientDto();

            Patient myPatient = PatientAdapter.PatientDtoToPatient(patient);

            myPatient.ShouldBeOfType(typeof(Patient));
        }

        private PatientDto CreatePatientDto()
        {
            return new PatientDto
            {
                Id = 3,
                Address = "Simfonijska 2",
                Age = 12,
                FirstName = "Sima",
                IsBlocked = false,
                Role = "Patient",
                IsMalicious = false,
                LastName = "Drazic",
                Username = "sima123",
                PhoneNumber = "555-333",
                Gender = "Male"
            };
        }

        private Patient CreatePatient()
        {
            return new Patient
            {
                Id = 3,
                Address = "Simfonijska 2",
                Age = 12,
                FirstName = "Sima",
                IsBlocked = false,
                Role = "Patient",
                IsMalicious = false,
                LastName = "Drazic",
                Username = "sima123",
                PhoneNumber = "555-333",
                Gender = "Male"
            };
        }
    }
}
