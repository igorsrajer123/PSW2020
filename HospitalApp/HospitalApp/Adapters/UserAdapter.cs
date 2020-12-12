using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class UserAdapter
    {
        public static User UserDtoToUser(UserDto userDto)
        {
            User user = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Role = userDto.Role,
                IsDeleted = userDto.IsDeleted,
                Address = userDto.Address,
                PhoneNumber = userDto.PhoneNumber
            };

            return user;
        }

        public static UserDto UserToUserDto(User user)
        {
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                IsDeleted = user.IsDeleted,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }
    }
}
