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
        private readonly DateLogic _dt = new DateLogic();

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

        [HttpDelete]
        [Route("/deleteDoctor/{id}")]
        public IActionResult Delete(int id)
        { 
            if (_doctorService.DeleteById(id) == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("/updateDoctor/{id}")]
        public IActionResult Update(int id, DoctorDto doctorDto)
        {
            if (_doctorService.UpdateById(id, doctorDto) == null)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        [Route("/getDate")]
        public IActionResult GetDate()
        {
            return Ok(_dt.DiscardRandomTimesString());
        }
    }
}
