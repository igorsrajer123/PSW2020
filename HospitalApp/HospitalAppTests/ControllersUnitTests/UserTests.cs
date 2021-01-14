using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Controllers;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests
{
    public class UserTests
    {
        [Fact]
        public void Get_all_users()
        { 
            UserController controller = new UserController(SetupRepository(null, null).Object);
            
            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(CreateUsers());
        }
        
        [Fact]
        public void Get_by_id()
        {
            UserDto myUser = CreateUsers().Find(u => u.Id == 1);
            UserController controller = new UserController(SetupRepository(myUser, null).Object);

            var actionResult = controller.GetById(myUser.Id);
           
            ConvertToObject(actionResult).ShouldBe(myUser);
        }

        [Fact]
        public void Update_user()
        {
            UserDto myUser = CreateUsers().Find(u => u.Id == 1);
            myUser.IsBlocked = true;
            myUser.FirstName = "AAA";
            User convertedUser = UserAdapter.UserDtoToUser(myUser);
            UserController controller = new UserController(SetupRepository(myUser, convertedUser).Object);

            var actionResult = controller.UpdateById(1, convertedUser);

            ConvertToObject(actionResult).ShouldBeSameAs(myUser);
        }

        [Fact]
        public void Block_user()
        {
            UserDto myUser = CreateUsers().Find(u => u.Id == 1);
            myUser.IsBlocked = true;
            UserController controller = new UserController(SetupRepository(myUser, null).Object);
           
            var actionResult = controller.BlockUser(1);

            ConvertToObject(actionResult).ShouldBeSameAs(myUser);
        }

        private List<UserDto> CreateUsers()
        {
            var users = new List<UserDto>();

            UserDto pera = new UserDto
            {
                Id = 1,
                FirstName = "Petar",
                LastName = "Peric",
                Address = "Tomiceva",
                IsBlocked = false,
                IsMalicious = false,
                PhoneNumber = "0000",
                Role = "Patient",
                Username = "pera123"
            };

            UserDto mika = new UserDto
            {
                Id = 2,
                FirstName = "Milan",
                LastName = "Peric",
                Address = "Sodoma",
                IsBlocked = false,
                IsMalicious = false,
                PhoneNumber = "5555",
                Role = "Patient",
                Username = "mika123"
            };

            users.Add(pera);
            users.Add(mika);

            return users;
        }

        private UserDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as UserDto;
        }

        private List<UserDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<UserDto>;
        }

        private Mock<IUserService> CreateRepository()
        {
            return new Mock<IUserService>();
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IUserService> SetupRepository(UserDto user, User convertedUser)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_users":
                    repository.Setup(m => m.GetAll()).Returns(CreateUsers());
                    break;
                case "Get_by_id":
                    repository.Setup(m => m.GetById(user.Id)).Returns(user);
                    break;
                case "Update_user":
                    repository.Setup(m => m.UpdateById(1, convertedUser)).Returns(user);
                    break;
                case "Block_user":
                    repository.Setup(m => m.BlockUser(user.Id)).Returns(user);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }
    }
}
