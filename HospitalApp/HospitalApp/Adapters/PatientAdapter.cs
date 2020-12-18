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
                Address = patientDto.Address,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                IsDeleted = patientDto.IsDeleted,
                PhoneNumber = patientDto.PhoneNumber,
                Username = patientDto.Username,
                Role = patientDto.Role,
                Age = patientDto.Age,
                Gender = patientDto.Gender,
                IsBlocked = patientDto.IsBlocked,
                AdministratorId = patientDto.AdministratorId,
                GeneralPractitionerId = patientDto.GeneralPractitionerId
            };

            return patient;
        }

        public static PatientDto PatientToPatientDto(Patient patient)
        {
            PatientDto patientDto = new PatientDto
            {
                Address = patient.Address,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                IsDeleted = patient.IsDeleted,
                PhoneNumber = patient.PhoneNumber,
                Username = patient.Username,
                Role = patient.Role,
                Age = patient.Age,
                Gender = patient.Gender,
                IsBlocked = patient.IsBlocked,
                AdministratorId = patient.AdministratorId,
                GeneralPractitionerId = patient.GeneralPractitionerId
            };

            return patientDto;
        }
    }
}
