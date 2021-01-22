using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class AdministratorService
    {
        private DbContextOptions<MyDbContext> _options;

        public AdministratorService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "AdminsDb").Options;
        }

        [Fact]
        public void Get_all_administrators()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.AdministratorService service = new HospitalApp.Services.AdministratorService(context);

                List<AdministratorDto> admins = service.GetAll();

                admins.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.AdministratorService service = new HospitalApp.Services.AdministratorService(context);

                AdministratorDto admin = service.GetById(1);

                admin.Id.ShouldBe(1);
            }
        }

        [Fact]
        public void Add()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.AdministratorService service = new HospitalApp.Services.AdministratorService(context);
                Administrator newAdmin = new Administrator { Id = 3, FirstName = "Admin", LastName = "Administratovic", Username = "kifla666", Role = "Administrator" };

                AdministratorDto admin = service.Add(newAdmin);

                admin.ShouldNotBeNull();
            }
        }

        #region "Helper methods"
        private void CreateAdministrators(MyDbContext context)
        {
            context.Administrators.Add(new Administrator
            {
                Id = 1,
                FirstName = "Sima",
                LastName = "Simonovic",
                IsBlocked = false,
                IsMalicious = false,
                Username = "sima023",
                PhoneNumber = "123456",
                Role = "Administrator",
                Password = "321",
                Address = "Address"
            });

            context.Administrators.Add(new Administrator
            {
                Id = 2,
                FirstName = "Ante",
                LastName = "Kifla",
                IsBlocked = false,
                IsMalicious = false,
                Username = "kifla123",
                PhoneNumber = "5553213",
                Role = "Administrator",
                Password = "123",
                Address = "Adresa!"
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateAdministrators(context);
        }
        #endregion
    }
}
