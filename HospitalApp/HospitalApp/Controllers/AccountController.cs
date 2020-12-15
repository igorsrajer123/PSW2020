using HospitalApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            this._dbContext = context;
        }

        [HttpPost]
        [Route("/login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            User myUser = _dbContext.Users.FirstOrDefault(b => b.Username == username);

            JsonConvert.SerializeObject(myUser, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            if (myUser != null && myUser.Password == password)
            {
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(myUser, Formatting.Indented, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));

                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, myUser.Username),
                    new Claim(ClaimTypes.Role, myUser.Role)
                });
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok();
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

        public IActionResult ExtractSessionUser()
        {
            User sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            if (sessionUser == null)
                return Ok();

            User user = _dbContext.Users.SingleOrDefault(u => u.Id == sessionUser.Id);
            return Ok(user);
        }
    }
}
