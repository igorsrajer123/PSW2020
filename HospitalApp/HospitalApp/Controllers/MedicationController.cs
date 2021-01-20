using HospitalApp.Contracts;
using HospitalApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        [Route("/getAllMedications")]
        public IActionResult GetAll()
        {
            return Ok(_medicationService.GetAll());
        }

        [HttpGet]
        [Route("/getMedicationById/{medicationId}")]
        public IActionResult GetById(int medicationId)
        {
            return Ok(_medicationService.GetById(medicationId));
        }

        [HttpPut]
        [Route("/addMedications")]
        public IActionResult AddMedicationsToSupply(List<MedicationDto> medicationsDto)
        {
            if (_medicationService.AddMedicationsToSupply(medicationsDto) == null)
                return NotFound();

            return Ok();
        }
    }
}
