using HospitalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private MyDbContext _dbContext;

        public AccountController(MyDbContext context)
        {
            this._dbContext = context;
        }

        [HttpGet]
        [Route("/index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            User myUser = _dbContext.Users.SingleOrDefault(b => b.Username == username);
            if (myUser != null && myUser.Password.Equals(password))
            {
                HttpContext.Session.SetString("username", myUser.Username);
                HttpContext.Session.SetString("id", myUser.Id.ToString());
            }

            return Ok();
        }
    }
}
