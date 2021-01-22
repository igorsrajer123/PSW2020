using HospitalApp.Adapters;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class ReferralService
    {
        private DbContextOptions<MyDbContext> _options;

        public ReferralService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "ReferralsDb").Options;
        }
        
        [Fact]
        public void Get_all_referrals()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService service = new HospitalApp.Services.ReferralService(context);

                List<ReferralDto> referrals = service.GetAll();

                referrals.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService service = new HospitalApp.Services.ReferralService(context);

                ReferralDto referral = service.GetById(1);

                referral.Id.ShouldBeEquivalentTo(1);
            }
        }
        
        [Fact]
        public void Remove_patients_referral()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService service = new HospitalApp.Services.ReferralService(context);
                Patient p = CreatePatient(context);

                service.RemovePatientsReferral(p);

                p.Referral.ShouldBeNull();
            }
        }

        [Fact]
        public void Get_appointments_referral()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService service = new HospitalApp.Services.ReferralService(context);

                ReferralDto referral = service.GetAppointmentsReferral(CreateAppointment(context));

                referral.Id.ShouldBe(2);
            }
        }

        #region "Helper methods"
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

        private Referral CreateReferral(MyDbContext context)
        {
            return new Referral
            {
                Id = 1000
            };
        }

        private Appointment CreateAppointment(MyDbContext context)
        {
            Appointment ap = new Appointment { Id = 5, PatientId = 12, DoctorId = 22 };
            context.Appointments.Add(ap);
            context.SaveChanges();

            return ap;
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
                GeneralPractitionerId = null,
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
                Role = "Patient",
                Referral = new Referral { Id = 3, IsDeleted = false, PatientId = 12}
            });

            context.SaveChanges();
        }

        private Patient CreatePatient(MyDbContext context)
        {
            Patient patient = new Patient { Id = 13, 
                                            Referral = CreateReferral(context)                                            
            };
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        private void CreateDoctors(MyDbContext context)
        {
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

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreatePatients(context);
            CreateDoctors(context);
            CreateReferrals(context);
        }
        #endregion
    }
}
