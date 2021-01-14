using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class PatientServiceTests
    {
        
        private DbContextOptions<MyDbContext> _options;

        public PatientServiceTests()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "PatientsDb").Options;
        }

        [Fact]
        public void Get_all_patients()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                DoctorService doctorService = new DoctorService(context);
                PatientService service = new PatientService(context, doctorService);
                List<PatientDto> patients = service.GetAll();

                patients.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
           
        }

        [Fact]
        public void Set_general_practitioner()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                DoctorService doctorService = new DoctorService(context);
                PatientService service = new PatientService(context, doctorService);
                PatientDto patient = service.SetGeneralPractitioner(11, 21);

                Assert.Equal(21, patient.GeneralPractitionerId);
            }
        }
        
        [Fact]
        public void Add()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                DoctorService doctorService = new DoctorService(context);
                PatientService service = new PatientService(context, doctorService);
                Patient newPatient = new Patient { Id = 13, Password = "5432412", FirstName = "Miladin", LastName = "Simic", Username = "userneki" };

                PatientDto patient = service.Add(newPatient);

                patient.ShouldNotBeNull();
            }
        }
        
        [Fact]
        public void Set_random_general_practitioner()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                DoctorService doctorService = new DoctorService(context);
                PatientService service = new PatientService(context, doctorService);
                PatientDto patient = service.GetById(12);
                Patient k = PatientAdapter.PatientDtoToPatient(patient);

                service.GiveRandomGeneralPractitioner(k);

                Assert.NotNull(k.GeneralPractitionerId);
            }
        }

        [Fact]
        public void Get_appointment_patient()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                DoctorService doctorService = new DoctorService(context);
                PatientService service = new PatientService(context, doctorService);

                PatientDto myPatient = service.GetAppointmentPatient(1);

                myPatient.Id.ShouldBe(11);
            }
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
                Role = "Patient"
            });

            context.SaveChanges();
        }

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

        private void CreateAppointments(MyDbContext context)
        {
            context.Appointments.Add(new Appointment
            {
                Id = 1,
                CancellationDate = "",
                Date = "",
                DoctorId = 21,
                Status = AppointmentStatus.Active,
                Time = "",
                PatientId = 11
            });

            context.SaveChanges();
        }

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreatePatients(context);
            CreateDoctors(context);
            CreateAppointments(context);
        }
    }
}
