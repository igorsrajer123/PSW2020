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
            this._dbContext = context;
        }

        public List<DoctorDto> GetAll()
        {
            List<DoctorDto> myDoctors = new List<DoctorDto>();

            _dbContext.Doctors.ToList().ForEach(doctor => myDoctors.Add(DoctorAdapter.DoctorToDoctorDto(doctor)));

            return myDoctors; 
        }

        public DoctorDto GetById(int id)
        {
            Doctor doctor = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == id);

            if (doctor == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(doctor);
        }

        public List<DoctorDto> GetByType(DoctorType type)
        {
            List<DoctorDto> myDoctors = new List<DoctorDto>();
            List<Doctor> doctors = _dbContext.Doctors.Where(doctor => doctor.Type == type).ToList();

            doctors.ForEach(doctor => myDoctors.Add(DoctorAdapter.DoctorToDoctorDto(doctor)));

            if (myDoctors == null)
                return null;

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

        public DoctorDto DeleteById(int id)
        {
            Doctor doctor = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == id);

            if (doctor == null)
                return null;

            doctor.IsDeleted = true;
            _dbContext.SaveChanges();

            return DoctorAdapter.DoctorToDoctorDto(doctor);
        }

        public DoctorDto UpdateById(int id, DoctorDto doctorDto)
        {
            Doctor doctor = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == id);

            if (doctor == null)
                return null;

            doctor.FirstName = doctorDto.FirstName;
            doctor.LastName = doctorDto.LastName;
            doctor.IsDeleted = doctorDto.IsDeleted;
            doctor.Type = doctorDto.Type;
            doctor.Appointments = doctorDto.Appointments;

            _dbContext.SaveChanges();

            return DoctorAdapter.DoctorToDoctorDto(doctor);
        }

        public DoctorDto GetGeneralPractitioner(int patientId)
        {
            Patient patient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (patient == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(patient.GeneralPractitioner);
        }

        public DoctorDto GetSpecialist(int patientId)
        {
            Patient patient = _dbContext.Patients.FirstOrDefault(patient => patient.Id == patientId);

            if (patient == null || patient.Referral == null)
                return null;

            Doctor d = _dbContext.Doctors.FirstOrDefault(doc => doc.Id == patient.Referral.SpecialistId);

            if (d == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(d);
        }
    }
}
