using HospitalApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Contracts
{
    public interface IMedicationService
    {
        List<MedicationDto> GetAll();

        MedicationDto GetById(int medicationId);

        List<MedicationDto> AddMedicationsToSupply(List<MedicationDto> medications);
    }
}
