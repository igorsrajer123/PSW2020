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

        PatientDto GetById(int patientId);

        PatientDto Add(Patient patient);

        PatientDto DeleteById(int patientId);

        PatientDto UpdateById(int patientId, PatientDto patientDto);

        PatientDto SetGeneralPractitioner(int patientId, int doctorId);

        DoctorDto GetGeneralPractitioner(int patientId);
    }
}
