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

            return Ok();
        }

        [HttpGet]
        [Route("/getPatientAppointments/{patientId}")]
        public IActionResult GetPatientAppointments(int patientId)
        {
            if (_appointmentService.GetPatientAppointments(patientId) == null)
                return NotFound();

            return Ok(_appointmentService.GetPatientAppointments(patientId));
        }

        [HttpPut]
        [Route("/cancelAppointment/{appointmentId}")]
        public IActionResult CancelAppointment(int appointmentId)
        {
            if (_appointmentService.CancelAppointment(appointmentId) == null)
                return NotFound();

            return Ok();
        }


    }
}
