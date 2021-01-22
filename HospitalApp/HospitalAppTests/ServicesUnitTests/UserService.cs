using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class UserService
    {
        private DbContextOptions<MyDbContext> _options;

        public UserService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "UsersDb").Options;
        }

        [Fact]
        public void Get_all_users()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.UserService service = new HospitalApp.Services.UserService(context);

                List<UserDto> users = service.GetAll();

                users.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.UserService service = new HospitalApp.Services.UserService(context);

                UserDto user = service.GetById(666);

                user.Id.ShouldBeEquivalentTo(666);
            }
        }

        [Fact]
        public void Block_user()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.UserService service = new HospitalApp.Services.UserService(context);

                UserDto user = service.BlockUser(666);

                user.IsBlocked.ShouldBe(true);
            }
        }

        [Fact]
        public void Update_user()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.UserService service = new HospitalApp.Services.UserService(context);
                User updatedUser = new User { FirstName = "mihajlo", IsBlocked = false, LastName = "misa", Username = "username", Password = "555" };

                UserDto user = service.UpdateById(666, updatedUser);

                user.FirstName.ShouldBe("mihajlo");
            }
        }

        #region "Helper methods"
        private void CreateUsers(MyDbContext context)
        {
            context.Users.Add(new User
            {
                Id = 666,
                FirstName = "Sima",
                LastName = "Simonovic",
                IsBlocked = false,
                IsMalicious = false,
                Username = "sima023",
                PhoneNumber = "123456",
                Role = "Patient"
            });

            context.Users.Add(new User
            {
                Id = 7777,
                FirstName = "Ante",
                LastName = "Kifla",
                IsBlocked = false,
                IsMalicious = false,
                Username = "kifla123",
                PhoneNumber = "5553213",
                Role = "Doctor"
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateUsers(context);
        }
        #endregion
    }
}
