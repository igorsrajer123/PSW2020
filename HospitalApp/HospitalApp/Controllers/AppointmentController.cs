using HospitalApp.Contracts;
using HospitalApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("/getAllAppointments")]
        public IActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        [HttpPost]
        [Route("/addAppointment")]
        public IActionResult Add(AppointmentDto appointmentDto)
        {
            if (_appointmentService.Add(appointmentDto) == null)
                return NotFound();

            return Ok(appointmentDto);
        }

        [HttpGet]
        [Route("/getPatientAppointments/{patientId}")]
        public IActionResult GetPatientAppointments(int patientId)
        {
            if (_appointmentService.GetPatientAppointments(patientId) == null)
                return NotFound();

            return Ok(_appointmentService.GetPatientAppointments(patientId));
        }

        [HttpGet]
        [Route("/getDoctorAppointments/{doctorId}")]
        public IActionResult GetDoctorAppointments(int doctorId)
        {
            if (_appointmentService.GetDoctorAppointments(doctorId) == null)
                return NotFound();

            return Ok(_appointmentService.GetDoctorAppointments(doctorId));
        }

        [HttpPut]
        [Route("/cancelAppointment/{appointmentId}")]
        public IActionResult CancelAppointment(int appointmentId)
        {
            if (_appointmentService.CancelAppointment(appointmentId) == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("/appointmentDone/{appointmentId}")]
        public IActionResult SetAppointmentDone(int appointmentId)
        {
            if (_appointmentService.SetAppointmentDone(appointmentId) == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("/finishAppointment/{appointmentId}")]
        public IActionResult FinishAppointment(int appointmentId)
        {
            if (_appointmentService.FinishAppointment(appointmentId) == null)
                return NotFound();

            return Ok();
        }
    }
}
