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
    public class DoctorController
    {
        [Fact]
        public void Get_all_doctors()
        {
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(null, null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateDoctors());
        }

        [Fact]
        public void Get_by_id()
        {
            DoctorDto myDoctor = CreateDoctors().Find(d => d.Id == 1);
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(myDoctor, null).Object);

            var actionResult = controller.GetById(myDoctor.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myDoctor);
        }

        [Fact]
        public void Get_by_type()
        {
            List<DoctorDto> specialists = CreateDoctors().FindAll(doctor => doctor.Type == DoctorType.Specialist);
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(null, specialists).Object);

            var actionResult = controller.GetByType(DoctorType.Specialist);

            ConvertToList(actionResult).ShouldBeEquivalentTo(specialists);
        }

        [Fact]
        public void Add_doctor()
        {
            DoctorDto myDoctor = CreateDoctor();
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(myDoctor, null).Object);

            var actionResult = controller.Add(myDoctor);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myDoctor);
        }

        [Fact]
        public void Get_general_practitioner()
        {
            PatientDto patient = CreatePatient();
            DoctorDto doctor = CreateDoctors().Find(d => d.Id == patient.GeneralPractitionerId);
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(doctor, null).Object);

            var actionResult = controller.GetGeneralPractitioner(patient.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(doctor);
        }

        [Fact]
        public void Get_specialist()
        {
            PatientDto patient = CreatePatient();
            ReferralDto referral = CreateReferral();
            DoctorDto doctor = CreateDoctors().Find(d => d.Id == referral.SpecialistId && patient.Id == referral.PatientId);
            HospitalApp.Controllers.DoctorController controller = new HospitalApp.Controllers.DoctorController(this.SetupRepository(doctor, null).Object);

            var actionResult = controller.GetSpecialist(patient.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(doctor);
        }

        #region "Helper function"
        private List<DoctorDto> CreateDoctors()
        {
            List<DoctorDto> doctors = new List<DoctorDto>();

            DoctorDto doctor1 = new DoctorDto
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

            DoctorDto doctor2 = new DoctorDto
            {
                Id = 2,
                Address = "Address",
                FirstName = "IME",
                LastName = "PREZIME",
                IsMalicious = false,
                IsBlocked = false,
                PhoneNumber = "54321",
                Role = "Doctor",
                Type = DoctorType.Specialist,
                Username = "user123",
                WorkingDays = null
            };

            doctors.Add(doctor1);
            doctors.Add(doctor2);

            return doctors;

        }

        private DoctorDto CreateDoctor()
        {
            return new DoctorDto
            {
                Id = 3,
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

        public PatientDto CreatePatient()
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
                Gender = "Male",
                GeneralPractitionerId = 1
            };
        }

        private ReferralDto CreateReferral()
        {
            return new ReferralDto
            {
                Id = 1,
                IsDeleted = false,
                PatientId = 3,
                SpecialistId = 1
            };
        }

        private DoctorDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as DoctorDto;
        }

        private List<DoctorDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<DoctorDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IDoctorService> CreateRepository()
        {
            return new Mock<IDoctorService>();
        }

        private Mock<IDoctorService> SetupRepository(DoctorDto doctor, List<DoctorDto> specialists)
        {
            var repository = CreateRepository();
            int patientId = 3;

            switch (GetCallingMethod())
            {
                case "Get_all_doctors":
                    repository.Setup(m => m.GetAll()).Returns(CreateDoctors());
                    break;
                case "Get_by_id":
                    repository.Setup(m => m.GetById(doctor.Id)).Returns(doctor);
                    break;
                case "Get_by_type":
                    repository.Setup(m => m.GetByType(DoctorType.Specialist)).Returns(specialists);
                    break;
                case "Add_doctor":
                    repository.Setup(m => m.Add(doctor)).Returns(doctor);
                    break;
                case "Get_general_practitioner":
                    repository.Setup(m => m.GetGeneralPractitioner(patientId)).Returns(doctor);
                    break;
                case "Get_specialist":
                    repository.Setup(m => m.GetSpecialist(patientId)).Returns(doctor);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }
        #endregion
    }
}
