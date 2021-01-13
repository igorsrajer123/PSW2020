using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppTests.ServicesTests
{
    public class InMemoryDatabase
    {
        private DbContextOptions<MyDbContext> _repository;
        public MyDbContext Context;

        public InMemoryDatabase()
        {
            _repository = CreateRepository();
            Context = new MyDbContext(_repository);
        }

        private DbContextOptions<MyDbContext> CreateRepository()
        {
            return new DbContextOptionsBuilder<MyDbContext>()
                            .UseInMemoryDatabase(databaseName: "DbContext")
                            .Options;
        }

        public void CreateUsers()
        {
            Context.Users.Add(new User
            {
                Id = 666,
                FirstName = "Sima",
                LastName = "Simonovic",
                IsBlocked = false,
                IsMalicious = false,
                Username = "sima023",
                PhoneNumber = "123456",
                Role = "Patient"
            });

            Context.Users.Add(new User
            {
                Id = 7777,
                FirstName = "Ante",
                LastName = "Kifla",
                IsBlocked = false,
                IsMalicious = false,
                Username = "kifla123",
                PhoneNumber = "5553213",
                Role = "Doctor"
            });

            Context.SaveChanges();
        }

        public void CreateAdministrators()
        {
            Context.Administrators.Add(new Administrator
            {
                Id = 1,
                FirstName = "Sima",
                LastName = "Simonovic",
                IsBlocked = false,
                IsMalicious = false,
                Username = "sima023",
                PhoneNumber = "123456",
                Role = "Administrator",
                Password = "321",
                Address = "Address"
            });

            Context.Administrators.Add(new Administrator
            {
                Id = 2,
                FirstName = "Ante",
                LastName = "Kifla",
                IsBlocked = false,
                IsMalicious = false,
                Username = "kifla123",
                PhoneNumber = "5553213",
                Role = "Administrator",
                Password = "123",
                Address = "Adresa!"
            });

            Context.SaveChanges();
        }

        public void CreateFeedbacks()
        {
            Context.Feedbacks.Add(new Feedback
            {
                Id = 1,
                Date = "2020-05-05",
                IsDeleted = false,
                IsVisible = false,
                Text = "Tekst!",
                PatientId = 11
            });

            Context.Feedbacks.Add(new Feedback
            {
                Id = 2,
                Date = "2020-11-07",
                IsDeleted = false,
                IsVisible = true,
                Text = "Tekst2!",
                PatientId = 12
            });

            Context.SaveChanges();
        }

        public void CreatePatients()
        {
            Context.Patients.Add(new Patient
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
                GeneralPractitionerId = 0,
                Role = "Patient"
            });

            Context.Patients.Add(new Patient
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
                GeneralPractitionerId = 0,
                Role = "Patient"
            });

            Context.SaveChanges();
        }

        public void CreateDoctors()
        {
            Context.Doctors.Add(new Doctor
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

            Context.Doctors.Add(new Doctor
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

            Context.SaveChanges();
        }

        public void CreateAppointments()
        {
            Context.Appointments.Add(new Appointment
            {
                Id = 1,
                CancellationDate = "",
                Date = "",
                DoctorId = 21,
                PatientId = 11,
                Status = AppointmentStatus.Active,
                Time = ""
            });

            Context.Appointments.Add(new Appointment
            {
                Id = 2,
                CancellationDate = "",
                Date = "",
                DoctorId = 22,
                PatientId = 12,
                Status = AppointmentStatus.Active,
                Time = ""
            });

            Context.SaveChanges();
        }

        public async void CheckIfContextEmpty()
        {
            int count = await Context.Users.CountAsync();
            if (count < 2)
            {
                CreateUsers();
                CreateFeedbacks();
                CreateAdministrators();
                CreatePatients();
                CreateDoctors();
                CreateAppointments();
            }
        }
    }
}
