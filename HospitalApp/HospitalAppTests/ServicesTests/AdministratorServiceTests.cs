using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class AdministratorServiceTests
    {
        private InMemoryDatabase _dataBase;
        private AdministratorService _service;

        public AdministratorServiceTests()
        {
            _dataBase = new InMemoryDatabase();
            _service = new AdministratorService(_dataBase.Context);
            _dataBase.CheckIfContextEmpty();
        }

        [Fact]
        public void Get_all_administrators()
        {
            List<AdministratorDto> admins = _service.GetAll();

            admins.Count.ShouldBe(GetAdminCount().Result);
        }

        [Fact]
        public void Get_by_id()
        {
            AdministratorDto admin = _service.GetById(1);

            admin.Id.ShouldBe(1);
        }

        [Fact]
        public void Add()
        {
            Administrator newAdmin = new Administrator { Id = 3, FirstName = "Admin", LastName = "Administratovic", Username = "kifla666", Role = "Administrator"};
            AdministratorDto admin = _service.Add(newAdmin);

            Assert.Equal(3, GetAdminCount().Result);
        }

        private async Task<int> GetAdminCount()
        {
            return await _dataBase.Context.Administrators.CountAsync();
        }
    }
}
