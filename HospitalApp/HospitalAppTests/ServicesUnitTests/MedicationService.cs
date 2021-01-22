using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.ServicesUnitTests
{
    public class MedicationService
    {
        private DbContextOptions<MyDbContext> _options;

        public MedicationService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "MedicationsDb").Options;
        }

        [Fact]
        public void Get_all_medications()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.MedicationService service = new HospitalApp.Services.MedicationService(context);

                List<MedicationDto> medications = service.GetAll();

                medications.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.MedicationService service = new HospitalApp.Services.MedicationService(context);

                MedicationDto medication = service.GetById(2);

                medication.Id.ShouldBeEquivalentTo(2);
            }
        }

        [Fact]
        public void Add_medications_to_supply()
        {
            using(var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                List<MedicationDto> newMeds = new List<MedicationDto>();
                newMeds.Add(new MedicationDto() {Id = 1, Quantity = 5 });
                HospitalApp.Services.MedicationService service = new HospitalApp.Services.MedicationService(context);
                
                List<MedicationDto> medications = service.AddMedicationsToSupply(newMeds);

                medications.ShouldNotBeNull();
            }
        }

        #region "Helper methods"
        private void CreateMedications(MyDbContext context)
        {
            context.Medications.Add(new Medication
            {
                Id = 1,
                Name = "Fervex",
                Quantity = 5
            });

            context.Medications.Add(new Medication
            {
                Id = 2,
                Name = "Flonivil",
                Quantity = 5
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateMedications(context);
        }
        #endregion
    }
}
