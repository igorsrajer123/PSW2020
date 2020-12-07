using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class PatientService : IPatientService
    {
        private MyDbContext _dbContext;

        public PatientService(MyDbContext context)
        {
            this._dbContext = context;
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
            if (patient == null)
                return null;

            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();

            PatientDto patientDto = PatientAdapter.PatientToPatientDto(patient);

            return patientDto;
        }

        public PatientDto DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public PatientDto UpdateById(int id, PatientDto patientDto)
        {
            throw new NotImplementedException();
        }
    }
}
