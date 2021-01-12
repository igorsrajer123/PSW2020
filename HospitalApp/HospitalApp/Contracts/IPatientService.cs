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

        PatientDto SetGeneralPractitioner(int patientId, int doctorId);

        PatientDto GetAppointmentPatient(int appointmentId);
    }
}
