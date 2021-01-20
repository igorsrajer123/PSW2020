using HospitalApp.Dtos;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Adapters
{
    public class MedicationAdapter
    {
        public static Medication MedicationDtoToMedication(MedicationDto medicationDto)
        {
            Medication medication = new Medication
            {
                Id = medicationDto.Id,
                Name = medicationDto.Name,
                Quantity = medicationDto.Quantity
            };

            return medication;
        }

        public static MedicationDto MedicationToMedicationDto(Medication medication)
        {
            MedicationDto medicationDto = new MedicationDto
            {
                Id = medication.Id,
                Name = medication.Name,
                Quantity = medication.Quantity
            };

            return medicationDto;
        }
    }
}
