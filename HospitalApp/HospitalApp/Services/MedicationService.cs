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
    public class MedicationService : IMedicationService
    {
        private MyDbContext _dbContext;

        public MedicationService(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<MedicationDto> AddMedicationsToSupply(List<MedicationDto> medications)
        {
            List<Medication> dbMedications = _dbContext.Medications.ToList();
            
            foreach(Medication m in dbMedications)
                foreach(MedicationDto m2 in medications)
                    if (m2.Id.Equals(m.Id))
                        m.Quantity += m2.Quantity;

            _dbContext.SaveChanges();
            return medications;
        }

        public List<MedicationDto> GetAll()
        {
            List<MedicationDto> myMedications = new List<MedicationDto>();
            _dbContext.Medications.ToList().ForEach(medication => myMedications.Add(MedicationAdapter.MedicationToMedicationDto(medication)));

            return myMedications;
        }

        public MedicationDto GetById(int medicationId)
        {
            Medication myMedication = _dbContext.Medications.SingleOrDefault(medication => medication.Id == medicationId);

            if (myMedication == null) return null;

            return MedicationAdapter.MedicationToMedicationDto(myMedication);
        }
    }
}
