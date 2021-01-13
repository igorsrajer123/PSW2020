using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class UserServiceTests
    {
        private InMemoryDatabase _dataBase;
        private UserService _service;
        
        public UserServiceTests()
        {
            _dataBase = new InMemoryDatabase();
            _service = new UserService(_dataBase.Context);
            _dataBase.CheckIfContextEmpty();
        }

        [Fact]
        public void Get_all_users()
        {
            List<UserDto> users = _service.GetAll();

            users.Count.ShouldBe(GetUserCount().Result);
        }

        [Fact]
        public void Get_by_id()
        {
            UserDto user = _service.GetById(666);

            user.Id.ShouldBeEquivalentTo(666);
        }

        [Fact]
        public void Block_user()
        {
            UserDto user = _service.BlockUser(666);

            user.IsBlocked.ShouldBe(true);
        }

        [Fact]
        public void Update_user()
        {
            User updatedUser = new User {FirstName = "mihajlo", IsBlocked = false, LastName = "misa", Username = "username", Password = "555" };
            UserDto user = _service.UpdateById(666, updatedUser);

            user.FirstName.ShouldBe("mihajlo");
        }
      
        private async Task<int> GetUserCount()
        {
            return await _dataBase.Context.Users.CountAsync();
        }
    }
}
