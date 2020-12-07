using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class PatientAdapter
    {
        public static Patient PatientDtoToPatient(PatientDto patientDto)
        {
            Patient patient = new Patient
            {
                Id = patientDto.Id,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                Username = patientDto.Username,
                IsDeleted = patientDto.IsDeleted,
                Age = patientDto.Age,
                Gender = patientDto.Gender,
                IsBlocked = patientDto.IsBlocked,
                BlockedBy = patientDto.BlockedBy,
                Examinations = patientDto.Examinations,
                Feedback = patientDto.Feedback
            };

            return patient;
        }

        public static PatientDto PatientToPatientDto(Patient patient)
        {
            PatientDto patientDto = new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Username = patient.Username,
                IsDeleted = patient.IsDeleted,
                Age = patient.Age,
                Gender = patient.Gender,
                IsBlocked = patient.IsBlocked,
                BlockedBy = patient.BlockedBy,
                Examinations = patient.Examinations,
                Feedback = patient.Feedback
            };

            return patientDto;
        }
    }
}
