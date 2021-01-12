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
                Username = doctorDto.Username,
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                IsBlocked = doctorDto.IsBlocked,
                IsMalicious = doctorDto.IsMalicious,
                PhoneNumber = doctorDto.PhoneNumber,
                Role = doctorDto.Role,
                Address = doctorDto.Address,
                Type = doctorDto.Type,
                WorkingDays = doctorDto.WorkingDays
            };

            return doctor;
        }

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto doctorDto = new DoctorDto
            {
                Id = doctor.Id,
                Username = doctor.Username,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                IsBlocked = doctor.IsBlocked,
                IsMalicious = doctor.IsMalicious,
                PhoneNumber = doctor.PhoneNumber,
                Role = doctor.Role,
                Address = doctor.Address,
                Type = doctor.Type,
                WorkingDays = doctor.WorkingDays
            };

            return doctorDto;
        }
    }
}
