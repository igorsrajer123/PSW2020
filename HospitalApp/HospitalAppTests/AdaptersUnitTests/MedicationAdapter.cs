using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.AdaptersUnitTests
{
    public class MedicationAdapter
    {
        [Fact]
        public void Medication_to_medication_dto()
        {
            Medication medication = CreateMedication();

            MedicationDto myMedication = HospitalApp.Adapters.MedicationAdapter.MedicationToMedicationDto(medication);

            myMedication.ShouldBeOfType(typeof(MedicationDto)); 
        }

        [Fact]
        public void Medication_dto_to_medication()
        {
            MedicationDto medicationDto = CreateMedicationDto();

            Medication myMedication = HospitalApp.Adapters.MedicationAdapter.MedicationDtoToMedication(medicationDto);

            myMedication.ShouldBeOfType(typeof(Medication));
        }

        #region "Helper functions"
        private Medication CreateMedication()
        {
            Medication medication = new Medication
            {
                Id = 1,
                Name = "Fervex",
                Quantity = 5213
            };

            return medication;
        }

        private MedicationDto CreateMedicationDto()
        {
            MedicationDto medicationDto = new MedicationDto
            {
                Id = 5,
                Name = "Flonivil",
                Quantity = 123
            };

            return medicationDto;
        }
        #endregion
    }
}
