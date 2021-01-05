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
    public class ReferralController : ControllerBase
    {
        private IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
        }

        [HttpGet]
        [Route("/getAllReferrals")]
        public IActionResult GetAll()
        {
            if (_referralService.GetAll() == null)
                return NotFound();

            return Ok(_referralService.GetAll());
        }

        [HttpGet]
        [Route("/getReferral/{referralId}")]
        public IActionResult GetById(int referralId)
        {
            if (_referralService.GetById(referralId) == null)
                return NotFound();

            return Ok(_referralService.GetById(referralId));
        }

        [HttpPost]
        [Route("/addReferral")]
        public IActionResult Add(ReferralDto referralDto)
        {
            if (_referralService.Add(referralDto) == null)
                return NotFound();

            return Ok();
        }
    }
}
