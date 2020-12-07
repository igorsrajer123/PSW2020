using HospitalApp.Contracts;
using HospitalApp.Dtos;
using HospitalApp.Models;
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
    public class AdministratorController : ControllerBase
    {
        private IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        [Route("/getAllAdmins")]
        public IActionResult GetAll()
        {
            return Ok(_administratorService.GetAll());
        }

        [HttpGet]
        [Route("/getAdminById/{id}")]
        public IActionResult GetById(int id)
        {
            if (_administratorService.GetById(id) == null)
                return NotFound();

            return Ok(_administratorService.GetById(id));
        }

        [HttpPost]
        [Route("/addAdmin")]
        public IActionResult Add(Administrator administrator)
        {
            if (_administratorService.Add(administrator) == null)
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("/deleteAdmin/{id}")]
        public IActionResult Delete(int id)
        {
            if (_administratorService.DeleteById(id) == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Route("/updateAdmin/{id}")]
        public IActionResult Update(int id, AdministratorDto administratorDto)
        {
            if (_administratorService.UpdateById(id, administratorDto) == null)
                return NotFound();

            return Ok();
        }
    }
}
