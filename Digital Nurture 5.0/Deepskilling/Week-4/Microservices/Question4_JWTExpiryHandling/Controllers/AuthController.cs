using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Question4_JWTExpiryHandling.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Question4_JWTExpiryHandling.Controllers
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
            if (login.Username == "admin" && login.Password == "admin123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "Admin"),
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
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiry = token.ValidTo
                });
            }

            return Unauthorized(new
            {
                Message = "Invalid Username or Password"
            });
        }

        [HttpGet("token-info")]
        public IActionResult TokenInfo()
        {
            return Ok(new
            {
                TokenExpiry = "1 Minute",
                Description = "After 1 minute the JWT token becomes invalid and protected APIs return 401 Unauthorized."
            });
        }
    }
}