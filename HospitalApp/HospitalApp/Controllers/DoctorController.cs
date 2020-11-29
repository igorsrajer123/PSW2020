using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly MyDbContext _dbContext;

        public DoctorController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("/getAllDoctors")]
        public IActionResult Get()
        {
            List<Doctor> result = new List<Doctor>();
            _dbContext.Doctors.ToList().ForEach(doctor => result.Add(doctor));

            return Ok(result);
        }
    }
}
