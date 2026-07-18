using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Question2_SecureAPIEndpoint.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Question2_SecureAPIEndpoint.Controllers
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
            // Sample user validation
            if (login.Username == "admin" && login.Password == "admin123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Username)
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
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized(new
            {
                Message = "Invalid Username or Password"
            });
        }
    }
}