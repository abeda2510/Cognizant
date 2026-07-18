using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Question3_RoleBasedAuthorization.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Question3_RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login == null)
            {
                return BadRequest("Invalid Request");
            }

            // Sample User Validation
            if ((login.Username == "admin" && login.Password == "admin123") ||
                (login.Username == "user" && login.Password == "user123"))
            {
                string role = login.Username == "admin" ? "Admin" : "User";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var credentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(
                        Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])),
                    signingCredentials: credentials);

                return Ok(new
                {
                    Message = "Login Successful",
                    Username = login.Username,
                    Role = role,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized(new
            {
                Message = "Invalid Username or Password"
            });
        }

        [HttpGet("users")]
        public IActionResult GetSampleUsers()
        {
            var users = new[]
            {
                new
                {
                    Username = "admin",
                    Password = "admin123",
                    Role = "Admin"
                },
                new
                {
                    Username = "user",
                    Password = "user123",
                    Role = "User"
                }
            };

            return Ok(users);
        }
    }
}