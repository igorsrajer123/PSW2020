using HospitalApp.Adapters;
using HospitalApp.DateTimeLogic;
using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("/getAllDoctors")]
        public IActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        [HttpGet]
        [Route("/getDoctorById/{id}")]
        public IActionResult GetById(int id)
        {
            if (_doctorService.GetById(id) == null)
                return NotFound();

            return Ok(_doctorService.GetById(id));
        }

        [HttpGet]
        [Route("/getDoctorByType/{type}")]
        public IActionResult GetByType(DoctorType type)
        {
            if (_doctorService.GetByType(type) == null)
                return NotFound();

            return Ok(_doctorService.GetByType(type));
        }

        [HttpPost]
        [Route("/addDoctor")]
        public IActionResult Add(DoctorDto doctorDto)
        {
            if (_doctorService.Add(doctorDto) == null)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        [Route("/getGeneralPractitioner/{patientId}")]
        public IActionResult GetGeneralPractitioner(int patientId)
        {
            if (_doctorService.GetGeneralPractitioner(patientId) == null)
                return NotFound();

            return Ok(_doctorService.GetGeneralPractitioner(patientId));
        }

        [HttpGet]
        [Route("/getSpecialist/{patientId}")]
        public IActionResult GetSpecialist(int patientId)
        {
            if (_doctorService.GetSpecialist(patientId) == null)
                return NotFound();

            return Ok(_doctorService.GetSpecialist(patientId));
        }

        [HttpGet]
        [Route("/getAllSpecialists")]
        public IActionResult GetAllSpecialists()
        {
            if (_doctorService.GetAllSpecialists() == null)
                return NotFound();

            return Ok(_doctorService.GetAllSpecialists());
        }
    }
}
