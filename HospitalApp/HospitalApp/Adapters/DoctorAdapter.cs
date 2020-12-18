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
                Id = doctorDto.Id,
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Type = doctorDto.Type,
                IsDeleted = doctorDto.IsDeleted,
                WorkingDays = doctorDto.WorkingDays
            };

            return doctor;
        }

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto doctorDto = new DoctorDto
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Type = doctor.Type,
                IsDeleted = doctor.IsDeleted,
                WorkingDays = doctor.WorkingDays
            };

            return doctorDto;
        }
    }
}
