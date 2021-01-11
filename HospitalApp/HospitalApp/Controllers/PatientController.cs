using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
        private IDoctorService _doctorService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("/getAllPatients")]
        public IActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        [HttpPost]
        [Route("/addPatient")]
        public IActionResult Add(Patient patient)
        {
            if (_patientService.Add(patient) == null)
                return NotFound();

            return Ok(PatientAdapter.PatientToPatientDto(patient));
        }

        [HttpGet]
        [Route("/getPatientById/{id}")]
        public IActionResult GetById(int id)
        {
            if (_patientService.GetById(id) == null)
                return NotFound();

            return Ok(_patientService.GetById(id));
        }

        [Authorize(Roles = "Patient")]
        [HttpPut]
        [Route("/setGeneralPractitioner/{patientId}/{doctorId}")]
        public IActionResult SetGeneralPractitioner(int patientId, int doctorId)
        {
            if (_patientService.SetGeneralPractitioner(patientId, doctorId) == null)
                return NotFound();

            return Ok();
        }
    }
}
