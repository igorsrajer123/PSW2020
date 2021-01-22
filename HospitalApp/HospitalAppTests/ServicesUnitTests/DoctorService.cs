using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class DoctorService
    {
        private DbContextOptions<MyDbContext> _options;

        public DoctorService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "DoctorsDb").Options;
        }

        [Fact]
        public void Get_all_doctors()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);

                List<DoctorDto> doctors = service.GetAll();

                doctors.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }
        
        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);

                DoctorDto doctor = service.GetById(22);

                Assert.Equal(22, doctor.Id);
            }
        }

        [Fact]
        public void Get_by_type()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);

                List<DoctorDto> generalPractitioners = service.GetByType(DoctorType.GeneralPractitioner);

                generalPractitioners.ShouldNotBeNull();
            }
        }

        [Fact]
        public void Add()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);
                DoctorDto newDoctor = new DoctorDto { Id = 23, FirstName = "Doktor", LastName = "Doktorica", Username = "doca3", Type = DoctorType.Specialist };

                DoctorDto doctor = service.Add(newDoctor);

                doctor.ShouldNotBeNull();
            }
        }

        [Fact]
        public void Get_general_practitioner()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);

                DoctorDto myGeneralPractitioner = service.GetGeneralPractitioner(11);

                myGeneralPractitioner.Id.ShouldBe(21);
            }
        }

        [Fact]
        public void Get_patient_specialist()
        {
            using(var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.DoctorService service = new HospitalApp.Services.DoctorService(context);

                DoctorDto mySpecialist = service.GetSpecialist(11);

                mySpecialist.Id.ShouldBe(22);
            }
        }

        #region "Helper methods"
        private void CreateDoctors(MyDbContext context)
        {
            context.Doctors.Add(new Doctor
            {
                Id = 21,
                IsMalicious = false,
                Address = "Radnicka 55",
                FirstName = "Marko",
                LastName = "Radakovic",
                IsBlocked = false,
                Password = "123",
                PhoneNumber = "555-333",
                Role = "Doctor",
                Type = DoctorType.GeneralPractitioner,
                Username = "doca1",
                WorkingDays = new string[] { }
            });

            context.Doctors.Add(new Doctor
            {
                Id = 22,
                IsMalicious = false,
                Address = "Radnicka 55",
                FirstName = "Aleksa",
                LastName = "Aleksijevic",
                IsBlocked = false,
                Password = "123",
                PhoneNumber = "555-333",
                Role = "Doctor",
                Type = DoctorType.Specialist,
                Username = "doca2",
                WorkingDays = new string[] { }
            });

            context.SaveChanges();
        }

        private void CreatePatients(MyDbContext context)
        {
            context.Patients.Add(new Patient
            {
                Id = 11,
                Age = 12,
                Address = "Frankopanova",
                CancelledAppointments = 1,
                FirstName = "Strahinja",
                LastName = "Egic",
                Gender = "Male",
                IsBlocked = false,
                Password = "123",
                IsMalicious = false,
                PhoneNumber = "0000",
                Username = "patient123",
                GeneralPractitionerId = 21,
                Role = "Patient"
            });

            context.Patients.Add(new Patient
            {
                Id = 12,
                Age = 22,
                Address = "Sergeja Cetkovica 2",
                CancelledAppointments = 3,
                FirstName = "Samir",
                LastName = "Samirovic",
                Gender = "Male",
                IsBlocked = false,
                Password = "123",
                IsMalicious = true,
                PhoneNumber = "0000",
                Username = "patient2",
                GeneralPractitionerId = null,
                Role = "Patient"
            });

            context.SaveChanges();
        }

        private void CreateReferrals(MyDbContext context)
        {
            context.Referrals.Add(new Referral
            {
                Id = 1,
                IsDeleted = false, 
                PatientId = 11,
                SpecialistId = 22
            });

            context.Referrals.Add(new Referral
            {
                Id = 2,
                IsDeleted = false,
                PatientId = 12,
                SpecialistId = 22
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateDoctors(context);
            CreatePatients(context);
            CreateReferrals(context);
        }
        #endregion
    }
}
