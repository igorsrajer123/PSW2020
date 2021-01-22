using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Services;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTests.ServicesTests
{
    public class AppointmentService
    {
        private DbContextOptions<MyDbContext> _options;

        public AppointmentService()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "AppointmentsDb").Options;
        }

        [Fact]
        public void Get_all_appointments()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);

                List<AppointmentDto> appointments = service.GetAll();

                appointments.Count.ShouldBeGreaterThanOrEqualTo(2);
            }
        }

        [Fact]
        public void Get_by_id()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);

                AppointmentDto appointment = service.GetById(1);

                appointment.Id.ShouldBe(1);
            }
        }

        [Fact]
        public void Set_appointment_done()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);

                AppointmentDto appointment = service.SetAppointmentDone(1);

                appointment.Status.ShouldBe(AppointmentStatus.Done);
            }
        }

        [Fact]
        public void Set_appointments_referral_deleted()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Appointment app = CreateOne(context);

                service.SetAppointmentsReferralDeleted(app);

                app.Patient.Referral.IsDeleted.ShouldBe(true);
            }
        }

        [Fact]
        public void Finish_appointment()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Appointment app = CreateOne(context);

                AppointmentDto appDto = service.FinishAppointment(app.Id);

                appDto.Status.ShouldBe(AppointmentStatus.Done);
            }
        }

        [Fact]
        public void Get_appointment_full_date_string()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Appointment app = CreateOne(context);

                DateTime dateAndTime = service.GetAppointmentFullDate(app);

                dateAndTime.ShouldBe(DateTime.Parse("2020-05-05 02 PM"));
            }
        }

        [Fact]
        public void Get_appointment_full_date()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Appointment app = CreateOne(context);

                string dateAndTime = service.GetAppointmentFullDateString(app);

                dateAndTime.ShouldBe("2020-05-05 02 PM");
            }
        }

        [Fact]
        public void Get_doctor_appointments()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Doctor d = CreateDoctor(context);


                List<AppointmentDto> apps =  service.GetDoctorAppointments(d.Id);

                apps.Count.ShouldBe(2);
            }
        }

        [Fact]
        public void Get_patient_appointments()
        {
            using (var context = new MyDbContext(_options))
            {
                SetupDatabase(context);
                HospitalApp.Services.ReferralService referralService = new HospitalApp.Services.ReferralService(context);
                HospitalApp.Services.AppointmentService service = new HospitalApp.Services.AppointmentService(context, referralService);
                Patient p = CreatePatient(context);

                List<AppointmentDto> apps = service.GetPatientAppointments(p.Id);

                p.Appointments.Count.ShouldBe(apps.Count);
            }
        }

        #region "Helper methods"
        private void CreateAppointments(MyDbContext context)
        {
            context.Appointments.Add(new Appointment
            {
                Id = 1,
                CancellationDate = "",
                Date = "2020-01-01",
                Time = "",
                Status = AppointmentStatus.Active,
                DoctorId = 21,
                PatientId = 11,
            });

            context.Appointments.Add(new Appointment
            {
                Id = 2,
                CancellationDate = "",
                Date = "",
                Time = "",
                Status = AppointmentStatus.Active,
                DoctorId = 22,
                PatientId = 12
            });

            context.SaveChanges();
        }

        private Appointment CreateOne(MyDbContext context)
        {
            Appointment app = new Appointment
            {
                Id = 5,
                Status = AppointmentStatus.Active,
                DoctorId = 22,
                PatientId = 7,
                Patient = CreatePatient(context),
                Date = "2020-05-05",
                Time = "02 PM"
            };

            context.Appointments.Add(app);
            context.SaveChanges();
            return app;
        }

        private List<Appointment> AppointmentsCreated(MyDbContext context)
        {
            List<Appointment> apps = new List<Appointment>();

           Appointment ap1 = new Appointment
            {
                Id = 6,
                CancellationDate = "",
                Date = "2020-01-01",
                Time = "",
                Status = AppointmentStatus.Active,
                DoctorId = 23,
                PatientId = 7,
            };

            Appointment ap2 = new Appointment
            {
                Id = 7,
                CancellationDate = "",
                Date = "",
                Time = "",
                Status = AppointmentStatus.Active,
                DoctorId = 23,
                PatientId = 7
            };

            apps.Add(ap1);
            apps.Add(ap2);
            context.Appointments.Add(ap1);
            context.Appointments.Add(ap2);
            context.SaveChanges();

            return apps;
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

        private Patient CreatePatient(MyDbContext context)
        {
            Patient p = new Patient
            {
                Id = 7,
                Referral = CreateReferral(context),
                Appointments = AppointmentsCreated(context)
            };
            context.Patients.Add(p);
            context.SaveChanges();
            return p;
        }

        private Referral CreateReferral(MyDbContext context)
        {
            Referral r = new Referral
            {
                Id = 69,
                PatientId = 7,
                SpecialistId = 22
            };

            context.Referrals.Add(r);
            context.SaveChanges();
            return r;
        }

        private Doctor CreateDoctor(MyDbContext context)
        {
            Doctor d = new Doctor
            {
                Id = 23,
                Type = DoctorType.Specialist,
                WorkingDays = Date(),
                Appointments = AppointmentsCreated(context)
            };

            context.Doctors.Add(d);
            context.SaveChanges();
            return d;
        }

        private string[] Date()
        {
            return new string[] { "2020-05-05 02 PM" };
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

        private void SetupDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            CreateDoctors(context);
            CreatePatients(context);
            CreateAppointments(context);
        }
        #endregion
    }
}
