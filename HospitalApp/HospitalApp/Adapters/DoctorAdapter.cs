using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class DoctorAdapter
    {
        public static Doctor DoctorDtoToDoctor(DoctorDto doctorDto)
        {
            Doctor doctor = new Doctor
            {
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Type = doctorDto.Type,
                Examinations = doctorDto.Examinations,
                IsDeleted = doctorDto.IsDeleted
            };

            return doctor;
        }

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto doctorDto = new DoctorDto
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Type = doctor.Type,
                Examinations = doctor.Examinations,
                IsDeleted = doctor.IsDeleted
            };

            return doctorDto;
        }
    }
}
