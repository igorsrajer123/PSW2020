using HospitalApp.Contracts;
using HospitalApp.Controllers;
using HospitalApp.Dtos;
using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace HospitalAppTests
{
    public class AppointmentTests
    {
        [Fact]
        public void Get_all_appointments()
        {
            List<AppointmentDto> appointments = CreateAppointments();
            AppointmentController controller = new AppointmentController(SetupRepository(null, null).Object);

            var actionResult = controller.GetAll();

            ConvertToList(actionResult).ShouldBeEquivalentTo(appointments);
        }

        [Fact]
        public void Add_appointment()
        {
            AppointmentDto myAppointment = CreateAppointment();
            AppointmentController controller = new AppointmentController(SetupRepository(myAppointment, null).Object);

            var actionResult = controller.Add(myAppointment);

            ConvertToObject(actionResult).ShouldBeEquivalentTo(myAppointment);
        }

        [Fact]
        public void Cancel_appointment()
        {
            AppointmentDto myAppointment = CreateAppointments().Find(a => a.Id == 1);
            myAppointment.Status = AppointmentStatus.Cancelled;
            AppointmentController controller = new AppointmentController(SetupRepository(myAppointment, null).Object);

            var actionResult = controller.CancelAppointment(myAppointment.Id);

            actionResult.ShouldBeOfType(typeof(OkResult));
        }

        [Fact]
        public void Appointment_done()
        {
            AppointmentDto myAppointment = CreateAppointments().Find(a => a.Id == 1);
            myAppointment.Status = AppointmentStatus.Done;
            AppointmentController controller = new AppointmentController(SetupRepository(myAppointment, null).Object);

            var actionResult = controller.SetAppointmentDone(myAppointment.Id);

            actionResult.ShouldBeOfType(typeof(OkResult));
        }

        [Fact]
        public void Finish_appointment()
        {
            AppointmentDto myAppointment = CreateAppointments().Find(a => a.Id == 1);
            myAppointment.Status = AppointmentStatus.Done;
            AppointmentController controller = new AppointmentController(SetupRepository(myAppointment, null).Object);

            var actionResult = controller.FinishAppointment(myAppointment.Id);

            actionResult.ShouldBeOfType(typeof(OkResult));
        }

        private List<AppointmentDto> CreateAppointments()
        {
            List<AppointmentDto> appointments = new List<AppointmentDto>();

            AppointmentDto appointment1 = new AppointmentDto
            {
                Id = 1,
                Date = "2020-05-01",
                Status = AppointmentStatus.Active,
                DoctorId = 1,
                PatientId = 1,
                Time = "00:00AM",
                CancellationDate = ""
            };

            AppointmentDto appointment2 = new AppointmentDto
            {
                Id = 2,
                Date = "2020-05-01",
                Status = AppointmentStatus.Done,
                DoctorId = 2,
                PatientId = 2,
                Time = "00:00AM",
                CancellationDate = ""
            };

            appointments.Add(appointment1);
            appointments.Add(appointment2);

            return appointments;
        }

        private AppointmentDto CreateAppointment()
        {
            return new AppointmentDto
            {
                Id = 3,
                Date = "2020-05-01",
                Status = AppointmentStatus.Active,
                DoctorId = 1,
                PatientId = 1,
                Time = "00:00AM",
                CancellationDate = ""
            };
        }

        private AppointmentDto ConvertToObject(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as AppointmentDto;
        }

        private List<AppointmentDto> ConvertToList(IActionResult actionResult)
        {
            return (actionResult as OkObjectResult).Value as List<AppointmentDto>;
        }

        private string GetCallingMethod()
        {
            StackTrace stackTrace = new StackTrace();
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        private Mock<IAppointmentService> CreateRepository()
        {
            return new Mock<IAppointmentService>();
        }

        private Mock<IAppointmentService> SetupRepository(AppointmentDto appointment, List<AppointmentDto> appointments)
        {
            var repository = CreateRepository();

            switch (GetCallingMethod())
            {
                case "Get_all_appointments":
                    repository.Setup(m => m.GetAll()).Returns(CreateAppointments());
                    break;
                case "Add_appointment":
                    repository.Setup(m => m.Add(appointment)).Returns(appointment);
                    break;
                case "Cancel_appointment":
                    repository.Setup(m => m.CancelAppointment(1)).Returns(appointment);
                    break;
                case "Appointment_done":
                    repository.Setup(m => m.SetAppointmentDone(1)).Returns(appointment);
                    break;
                case "Finish_appointment":
                    repository.Setup(m => m.FinishAppointment(1)).Returns(appointment);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            return repository;
        }

    }
}
