using HospitalApp.Contracts;
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

namespace HospitalAppTests.ControllersUnitTests
{
    public class MedicationController
    {
        [Fact]
        public void Get_all_medications()
        {
            HospitalApp.Controllers.MedicationController controller = new HospitalApp.Controllers.MedicationController(SetupRepository(null, null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateMedications());
        }

        [Fact]
        public void Get_by_id()
        {
            MedicationDto myMedication = CreateMedications().Find(m => m.Id == 1);
            HospitalApp.Controllers.MedicationController controller = new HospitalApp.Controllers.MedicationController(SetupRepository(myMedication, null).Object);

            var actionResult = controller.GetById(myMedication.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myMedication);
        }

        #region "Helper functions"
        private List<MedicationDto> CreateMedications()
        {
            var meds = new List<MedicationDto>();

            MedicationDto med1 = new MedicationDto
            {
                Id = 1,
                Name = "Fervex",
                Quantity = 5
            };

            MedicationDto med2 = new MedicationDto
            {
                Id = 2,
               Name = "Flonivil",
               Quantity = 5
            };

            meds.Add(med1);
            meds.Add(med2);

            return meds;
        }

        private MedicationDto CreateMedication()
        {
            return new MedicationDto()
            {
                Id = 3,
                Name = "Adderall",
                Quantity = 5
            };
        }

        private MedicationDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as MedicationDto;
        }

        private List<MedicationDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<MedicationDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IMedicationService> CreateRepository()
        {
            return new Mock<IMedicationService>();
        }

        private Mock<IMedicationService> SetupRepository(MedicationDto medication, List<MedicationDto> medications)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_medications":
                    repository.Setup(m => m.GetAll()).Returns(CreateMedications());
                    break;
                case "Get_by_id":
                    repository.Setup(m => m.GetById(medication.Id)).Returns(medication);
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
