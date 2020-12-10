using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using HospitalApp.Models;
using System.Security.Claims;

namespace HospitalApp.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private MyDbContext _dbContext;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                          ILoggerFactory logger,
                                          UrlEncoder encoder,
                                          ISystemClock clock, MyDbContext context) : base(options, logger, encoder, clock) => _dbContext = context;

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Authorization header was not found!"));

            AuthenticationTicket ticket = GiveUserAuthorizations();

            if (ticket != null)
                return Task.FromResult(AuthenticateResult.Success(ticket));
            else
                return Task.FromResult(AuthenticateResult.Fail("Authorization failed!"));
        }

        private User GetAuthenticatedUser()
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string username = credentials[0];
            string password = credentials[1];

            User myUser = _dbContext.Users.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            return myUser;
        }

        private AuthenticationTicket GiveUserAuthorizations()
        {
            User user = GetAuthenticatedUser();

            if (user != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                });
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return ticket;
            }
            else
            {
                return null;
            }
        }
    }
}
