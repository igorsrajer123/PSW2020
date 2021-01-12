using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Repositories
{
    public interface IDoctorService
    {
        List<DoctorDto> GetAll();

        DoctorDto GetById(int id);

        List<DoctorDto> GetByType(DoctorType type);

        DoctorDto Add(DoctorDto doctorDto);

        DoctorDto GetGeneralPractitioner(int patientId);

        DoctorDto GetSpecialist(int patientId);

        List<DoctorDto> GetAllSpecialists();
    }
}
