using HospitalApp.Contracts;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("/getUserById/{userId}")]
        public IActionResult GetById(int userId)
        {
            return Ok(_userService.GetById(userId));
        }

        [Authorize(Roles = "Administrator, Patient")]
        [HttpPut]
        [Route("/updateUser/{id}")]
        public IActionResult UpdateById(int id, User user)
        {
            if(_userService.UpdateById(id, user) == null)
                return NotFound();

            return Ok(_userService.UpdateById(id, user));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("/blockUser/{userId}")]
        public IActionResult BlockUser(int userId)
        {
            if (_userService.BlockUser(userId) == null)
                return NotFound();

            return Ok(_userService.BlockUser(userId));
        }
    }
}
