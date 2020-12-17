using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class PatientService : IPatientService
    {
        private MyDbContext _dbContext;
        private IDoctorService _doctorService;
        private IReferralService _referralService;

        public PatientService(MyDbContext context, IDoctorService doctorService, IReferralService referralService)
        {
            this._dbContext = context;
            _doctorService = doctorService;
        }

        public List<PatientDto> GetAll()
        {
            List<PatientDto> myPatients = new List<PatientDto>();

            _dbContext.Patients.ToList().ForEach(patient => myPatients.Add(PatientAdapter.PatientToPatientDto(patient)));

            return myPatients;
        }

        public PatientDto GetById(int id)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == id);

            if (patient == null)
                return null;

            return PatientAdapter.PatientToPatientDto(patient);
        }

        public PatientDto Add(Patient patient)
        {
            if (patient == null || patient.Password == null)
                return null;

            Patient existingPatient = _dbContext.Patients.SingleOrDefault(p => p.Username == patient.Username);
            if (existingPatient != null)
                return null;

            var rnd = new Random();
            List<DoctorDto> generalPractitioners = _doctorService.GetByType(DoctorType.GeneralPractitioner);
            patient.GeneralPractitionerId = generalPractitioners[rnd.Next(generalPractitioners.Count)].Id;
            patient.Role = "Patient";
            
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();

            PatientDto patientDto = PatientAdapter.PatientToPatientDto(patient);

            return patientDto;
        }

        public PatientDto DeleteById(int id)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == id);

            if (patient == null)
                return null;

            patient.IsDeleted = true;
            return PatientAdapter.PatientToPatientDto(patient);
        }

        public PatientDto UpdateById(int id, PatientDto patientDto)
        {
            throw new NotImplementedException();
        }

        public PatientDto SetGeneralPractitioner(int patientId, int doctorId)
        {
            Patient patient = _dbContext.Patients.SingleOrDefault(patient => patient.Id == patientId);
            Doctor myDoctor = _dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == doctorId);

            if (patient == null || myDoctor == null)
                return null;

            patient.GeneralPractitioner = myDoctor;
            _dbContext.SaveChanges();
            PatientDto patientDto = PatientAdapter.PatientToPatientDto(patient);

            return patientDto;
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

            if (patient == null)
                return null;

            if (patient.Referral == null)
                return null;

            Doctor d = _dbContext.Doctors.FirstOrDefault(doc => doc.Id == patient.Referral.SpecialistId);

            if (d == null)
                return null;

            return DoctorAdapter.DoctorToDoctorDto(d);
        }
    }
}
