
using BusinessObjectLayer;
using DomainLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ApiLayer.Models
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ProductDbContext _context;
        IAdminOperations _admin;
        IEnumerable<AdminLogin> _adminList;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock ,
            IAdminOperations admin,
            ProductDbContext context) : base(options, logger, encoder, clock)
        {
            _context = context;
            _admin = admin;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header not found");
            }
            else
            {
                var authenticateHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticateHeaderValue.Parameter);
                var credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string username = credentials[0];
                string password = credentials[1];
                _adminList = _admin.Get();
                AdminLogin admin = _adminList.FirstOrDefault(admin => admin.Username == username && admin.Password == password);

                if(admin == null)
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, admin.Username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                
            }
            

        }
    }
}
