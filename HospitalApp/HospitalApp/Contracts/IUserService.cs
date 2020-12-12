using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IUserService
    {
        List<UserDto> GetAll();

        UserDto UpdateById(int id, User user);
    }
}
