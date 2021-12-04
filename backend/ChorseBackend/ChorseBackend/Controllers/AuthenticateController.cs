using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ChorseBackend.Data;
using ChorseBackend.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChorseBackend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ChorseBackendContext _context;
        public AuthenticateController(IConfiguration configuration, ChorseBackendContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Client client)
        {
            var userExists = _context.Client.FirstOrDefault(x => x.username == client.username);
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            _context.Client.Add(client);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Created("User Registered Successfully",client);
            }
            return Problem();

            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(ClientLogin login)
        {
            var user = _context.Client.FirstOrDefault(x => x.username == login.username);
            if (user != null &&  user.password.Equals(login.password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }




    }
}
