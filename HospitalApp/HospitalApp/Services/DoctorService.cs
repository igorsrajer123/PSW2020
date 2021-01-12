using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories;
using System;
using System.Collections.Generic;
using HospitalApp.DateTimeLogic;
using System.Linq;

namespace HospitalApp.Services
{
    public class DoctorService : IDoctorService
    {
        private MyDbContext _dbContext;

        public DoctorService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<DoctorDto> GetAll()
        {
            List<DoctorDto> myDoctors = new List<DoctorDto>();

            _dbContext.Doctors.ToList().ForEach(doctor => myDoctors.Add(DoctorAdapter.DoctorToDoctorDto(doctor)));

            return myDoctors; 
        }

        public DoctorDto GetById(int doctorId)
        {
            Doctor myDoctor = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == doctorId);

            if (myDoctor == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(myDoctor);
        }

        public List<DoctorDto> GetByType(DoctorType type)
        {
            List<DoctorDto> myDoctors = new List<DoctorDto>();
            List<Doctor> doctors = _dbContext.Doctors.Where(doctor => doctor.Type == type).ToList();

            doctors.ForEach(doctor => myDoctors.Add(DoctorAdapter.DoctorToDoctorDto(doctor)));

            return myDoctors;
        }

        public DoctorDto Add(DoctorDto doctorDto)
        {
            if (doctorDto == null)
                return null;

            Doctor doctor = DoctorAdapter.DoctorDtoToDoctor(doctorDto);
            _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();

            return doctorDto;
        }

        public DoctorDto GetGeneralPractitioner(int patientId)
        {
            Patient myPatient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (myPatient == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(myPatient.GeneralPractitioner);
        }

        public DoctorDto GetSpecialist(int patientId)
        {
            Patient myPatient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (myPatient == null || myPatient.Referral == null || myPatient.Referral.IsDeleted)
                return null;

            if (_dbContext.Doctors.FirstOrDefault(doctor => doctor.Id == myPatient.Referral.SpecialistId) == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(_dbContext.Doctors.FirstOrDefault(doctor => doctor.Id == myPatient.Referral.SpecialistId));
        }

        public List<DoctorDto> GetAllSpecialists()
        {
           List<DoctorDto> myDoctors = new List<DoctorDto>();
           List<Doctor> doctors = _dbContext.Doctors.Where(doctor => doctor.Type == DoctorType.Specialist).ToList();

           doctors.ForEach(doctor => myDoctors.Add(DoctorAdapter.DoctorToDoctorDto(doctor)));

           return myDoctors;
        }
    }
}
