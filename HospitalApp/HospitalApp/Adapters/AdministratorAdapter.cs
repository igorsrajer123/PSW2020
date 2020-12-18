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
                Address = administratorDto.Address,
                FirstName = administratorDto.FirstName,
                LastName = administratorDto.LastName,
                IsDeleted = administratorDto.IsDeleted,
                PhoneNumber = administratorDto.PhoneNumber,
                Username = administratorDto.Username,
                Role = administratorDto.Role
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
                Address = administrator.Address,
                IsDeleted = administrator.IsDeleted,
                Role = administrator.Role,
                PhoneNumber = administrator.PhoneNumber
            };

            return administratorDto;
        }
    }
}
