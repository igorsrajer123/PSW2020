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
                PhoneNumber = patientDto.PhoneNumber,
                Username = patientDto.Username,
                Role = patientDto.Role,
                Age = patientDto.Age,
                Gender = patientDto.Gender,
                IsBlocked = patientDto.IsBlocked,
                GeneralPractitionerId = patientDto.GeneralPractitionerId,
                IsMalicious = patientDto.IsMalicious,
                CancelledAppointments = patientDto.CancelledAppointments
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
                PhoneNumber = patient.PhoneNumber,
                Username = patient.Username,
                Role = patient.Role,
                Age = patient.Age,
                Gender = patient.Gender,
                IsBlocked = patient.IsBlocked,
                GeneralPractitionerId = patient.GeneralPractitionerId,
                IsMalicious = patient.IsMalicious,
                CancelledAppointments = patient.CancelledAppointments
            };

            return patientDto;
        }
    }
}
