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
    public class AdministratorTests
    {
        [Fact]
        public void Get_all_administrators()
        {
            AdministratorController controller = new AdministratorController(SetupRepository(null, null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateAdministrators());
        }

        [Fact]
        public void Get_by_id()
        {
            AdministratorDto myAdmin = CreateAdministrators().Find(a => a.Id == 1);
            AdministratorController controller = new AdministratorController(SetupRepository(myAdmin, null).Object);

            var actionResult = controller.GetById(myAdmin.Id);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myAdmin);
        }

        [Fact]
        public void Add_administrator()
        {
            AdministratorDto myAdmin = CreateAdministrator();
            Administrator convertedAdmin = AdministratorAdapter.AdministratorDtoToAdministrator(myAdmin);
            AdministratorController controller = new AdministratorController(SetupRepository(myAdmin, convertedAdmin).Object);

            var actionResult = controller.Add(convertedAdmin);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myAdmin);
        }

        private List<AdministratorDto> CreateAdministrators()
        {
            var admins = new List<AdministratorDto>();

            AdministratorDto pera = new AdministratorDto
            {
                Id = 1,
                Address = "adresa",
                FirstName = "Admin",
                IsBlocked = false,
                IsMalicious = false,
                LastName = "Simic",
                PhoneNumber = "321321312",
                Role = "Administrator",
                Username = "admin"
            };

            AdministratorDto sima = new AdministratorDto
            {
                Id = 2,
                Address = "adresa3",
                FirstName = "kimonovic",
                IsBlocked = false,
                IsMalicious = false,
                LastName = "kimislav",
                PhoneNumber = "321321312",
                Role = "Administrator",
                Username = "admin123"
            };

            admins.Add(pera);
            admins.Add(sima);

            return admins;
        }

        private AdministratorDto CreateAdministrator()
        {
            return new AdministratorDto
            {
                Id = 3,
                Address = "Dudara",
                FirstName = "Kolac",
                IsBlocked = true,
                IsMalicious = true,
                LastName = "Egara",
                PhoneNumber = "5551312",
                Role = "Administrator",
                Username = "admin3"
            };
        }

        private AdministratorDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as AdministratorDto;
        }

        private List<AdministratorDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<AdministratorDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IAdministratorService> CreateRepository()
        {
            return new Mock<IAdministratorService>();
        }

        private Mock<IAdministratorService> SetupRepository(AdministratorDto admin, Administrator convertedAdministrator)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_administrators":
                    repository.Setup(m => m.GetAll()).Returns(CreateAdministrators());
                    break;
                case "Get_by_id":
                    repository.Setup(m => m.GetById(admin.Id)).Returns(admin);
                    break;
                case "Add_administrator":
                    repository.Setup(m => m.Add(convertedAdministrator)).Returns(admin);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }

    }
}
