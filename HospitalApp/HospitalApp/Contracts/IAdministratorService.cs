using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IAdministratorService
    {
        List<AdministratorDto> GetAll();

        AdministratorDto GetById(int id);

        AdministratorDto Add(Administrator administrator);

        AdministratorDto DeleteById(int id);

        AdministratorDto UpdateById(int id, AdministratorDto administratorDto);
    }
}
