using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class UserAdapter
    {   
        [Fact]
        public void User_to_user_dto()
        {
            UserDto user = CreateUserDto();

            User myUser = HospitalApp.Adapters.UserAdapter.UserDtoToUser(user);

            myUser.ShouldBeOfType(typeof(User));
        }

        [Fact]
        public void User_dto_to_user()
        {
            User user = CreateUser();

            UserDto myUser = HospitalApp.Adapters.UserAdapter.UserToUserDto(user);

            myUser.ShouldBeOfType(typeof(UserDto));
        }

        #region "Helper functions"
        private UserDto CreateUserDto()
        {
            return new UserDto
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
        }

        private User CreateUser()
        {
            return new User
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
        }
        #endregion
    }
}
