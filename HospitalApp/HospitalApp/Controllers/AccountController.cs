using HospitalApp.Adapters;
using HospitalApp.Contracts;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private MyDbContext _dbContext;

        public AccountController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("/login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            User myUser = _dbContext.Users.FirstOrDefault(user => user.Username == username);
            SerializeSessionUser(myUser);

            if (myUser != null && myUser.Password == password)
            {
                if (myUser.IsBlocked == true)
                    return BadRequest();

                return Ok(SetSessionStringAndClaims(myUser));
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(null));
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return Ok();
        }

        [HttpGet]
        [Route("/getSession")]
        public IActionResult GetCurrentSession()
        {
           if(HttpContext.Session.GetString("SessionUser") == null)
                return Ok();

           return ExtractSessionUser();
        }

        #region "Helper methods"
        public IActionResult ExtractSessionUser()
        {
            User sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            if (sessionUser == null)
                return Ok();

            User myUser = _dbContext.Users.SingleOrDefault(u => u.Id == sessionUser.Id);
            return Ok(myUser);
        }

        public IActionResult SerializeSessionUser(User user)
        {
            JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            return Ok();
        }

        public IActionResult SetSessionString(User user)
        {
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            }));

            return Ok();
        }

        public IActionResult SetSessionClaims(User user)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
            });
            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();
        }

        public IActionResult SetSessionStringAndClaims(User user)
        {
            SetSessionClaims(user);
            SetSessionString(user);
            return Ok();
        }
        #endregion
    }
}
