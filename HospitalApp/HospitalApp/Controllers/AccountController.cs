﻿using HospitalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        [Route("/login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            User myUser = _dbContext.Users.SingleOrDefault(b => b.Username == username);
            if (myUser != null && myUser.Password == password)
            {
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(myUser));

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(null));
            return Ok();
        }

        [HttpGet]
        [Route("/getUser")]
        public IActionResult GetCurrentUser()
        {
           if(HttpContext.Session.GetString("SessionUser") == null)
                return Ok();
            else
            {
                var info = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                return Ok(info);
            }
        }
    }
}
