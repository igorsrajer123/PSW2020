using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class AdministratorAdapter
    {
        public static Administrator AdministratorDtoToAdministrator(AdministratorDto administratorDto)
        {
            Administrator administrator = new Administrator
            {
                Id = administratorDto.Id,
                FirstName = administratorDto.FirstName,
                LastName = administratorDto.LastName,
                Username = administratorDto.Username,
                IsDeleted = administratorDto.IsDeleted,
                BlockedUsers = administratorDto.BlockedUsers
            };

            return administrator;
        }

        public static AdministratorDto AdministratoToAdministratorDto(Administrator administrator)
        {
            AdministratorDto administratorDto = new AdministratorDto
            {
                Id = administrator.Id,
                FirstName = administrator.FirstName,
                LastName = administrator.LastName,
                Username = administrator.Username,
                IsDeleted = administrator.IsDeleted,
                BlockedUsers = administrator.BlockedUsers
            };

            return administratorDto;
        }
    }
}
