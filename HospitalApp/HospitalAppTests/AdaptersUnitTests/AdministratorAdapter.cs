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
    public class AdministratorAdapter
    {
        [Fact]
        public void Administrator_to_administrator_dto()
        {
            Administrator admin = CreateAdministrator();

            AdministratorDto myAdmin = HospitalApp.Adapters.AdministratorAdapter.AdministratoToAdministratorDto(admin);

            myAdmin.ShouldBeOfType(typeof(AdministratorDto));
        }

        [Fact]
        public void Administrator_dto_to_administrator()
        {
            AdministratorDto admin = CreateAdministratorDto();

            Administrator myAdmin = HospitalApp.Adapters.AdministratorAdapter.AdministratorDtoToAdministrator(admin);

            myAdmin.ShouldBeOfType(typeof(Administrator));
        }

        #region "Helper functions"
        private AdministratorDto CreateAdministratorDto()
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

        private Administrator CreateAdministrator()
        {
            return new Administrator
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
        #endregion
    }
}
