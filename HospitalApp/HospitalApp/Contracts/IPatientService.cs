using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IPatientService
    {
        List<PatientDto> GetAll();

        PatientDto GetById(int id);

        PatientDto Add(Patient patient);

        PatientDto DeleteById(int id);

        PatientDto UpdateById(int id, PatientDto patientDto);
    }
}
