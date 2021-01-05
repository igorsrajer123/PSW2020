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
                IsBlocked = administratorDto.IsBlocked,
                PhoneNumber = administratorDto.PhoneNumber,
                Username = administratorDto.Username,
                Role = administratorDto.Role,
                IsMalicious = administratorDto.IsMalicious
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
                IsBlocked = administrator.IsBlocked,
                Role = administrator.Role,
                PhoneNumber = administrator.PhoneNumber,
                IsMalicious = administrator.IsMalicious
            };

            return administratorDto;
        }
    }
}
