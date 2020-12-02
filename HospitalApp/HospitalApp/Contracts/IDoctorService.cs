using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Repositories
{
    public interface IDoctorService : IBaseService<DoctorDto>
    {
        new List<DoctorDto> GetAll();

        DoctorDto GetById(int id);

        List<DoctorDto> GetByType(DoctorType type);

        new DoctorDto Add(DoctorDto doctorDto);

        new DoctorDto DeleteById(int id);

        new DoctorDto UpdateById(int id, DoctorDto doctorDto);
    }
}
