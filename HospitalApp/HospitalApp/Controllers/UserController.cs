using HospitalApp.Contracts;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("/getAllUsers")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize(Roles = "Administrator, Patient")]
        [HttpPut]
        [Route("/updateUser/{id}")]
        public IActionResult UpdateById(int id, User user)
        {
            if(_userService.UpdateById(id, user) == null)
                return NotFound();

            return Ok(user);
        }
    }
}
