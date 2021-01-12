using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Controllers;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class PatientTests
    {
        [Fact]
        public void Get_all_patients()
        {
            PatientController controller = new PatientController(SetupRepository(null, null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreatePatients());
        }

        [Fact]
        public void Get_by_id()
        {
            PatientDto myPatient = CreatePatients().Find(p => p.Id == 1);
            PatientController controller = new PatientController(SetupRepository(myPatient, null).Object);

            var actionResult = controller.GetById(myPatient.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myPatient);
        }

        [Fact]
        public void Add_patient()
        {
            PatientDto myPatient = CreatePatient();
            Patient convertedPatient = PatientAdapter.PatientDtoToPatient(myPatient);
            PatientController controller = new PatientController(SetupRepository(myPatient, convertedPatient).Object);

            var actionResult = controller.Add(convertedPatient);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myPatient);
        }

        [Fact]
        public void Set_general_practitioner()
        {
            PatientDto myPatient = CreatePatients().Find(p => p.Id == 1);
            myPatient.GeneralPractitionerId = 1;
            PatientController controller = new PatientController(SetupRepository(myPatient, null).Object);

            var actionResult = controller.SetGeneralPractitioner(myPatient.Id, 1);

            Assert.NotNull(ConvertToObject(actionResult));
            //ConvertToObject(actionResult).ShouldBe(myPatient);
        }

        private List<PatientDto> CreatePatients()
        {
            var patients = new List<PatientDto>();

            PatientDto mika = new PatientDto
            {
                Id = 1,
                Address = "Visnjiceva 32",
                Age = 55,
                FirstName = "Mihajlo",
                IsBlocked = false,
                Role = "Patient",
                IsMalicious = false,
                LastName = "Mihic",
                Username = "mika123",
                PhoneNumber = "555-333",
                Gender = "Male",
                GeneralPractitionerId = 2
            };

            PatientDto mitar = new PatientDto
            {
                Id = 2,
                Address = "Apatinska 32",
                Age = 52,
                FirstName = "Mitar",
                IsBlocked = true,
                Role = "Patient",
                IsMalicious = false,
                LastName = "Miric",
                Username = "mitar123",
                PhoneNumber = "555-333",
                Gender = "Male",
                GeneralPractitionerId = 2
            };

            patients.Add(mika);
            patients.Add(mitar);

            return patients;
        }

        private PatientDto CreatePatient()
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

        private PatientDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as PatientDto;
        }

        private List<PatientDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<PatientDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IPatientService> CreateRepository()
        {
            return new Mock<IPatientService>();
        }

        private Mock<IPatientService> SetupRepository(PatientDto patient, Patient convertedPatient)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_patients":
                    repository.Setup(m => m.GetAll()).Returns(CreatePatients());
                    break;
                case "Get_by_id":
                    repository.Setup(m => m.GetById(patient.Id)).Returns(patient);
                    break;
                case "Add_patient":
                    repository.Setup(m => m.Add(convertedPatient)).Returns(patient);
                    break;
                case "Set_general_practitioner":
                    repository.Setup(m => m.SetGeneralPractitioner(patient.Id, 1)).Returns(patient);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }
    }
}
