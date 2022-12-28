using Duffnization.API.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Duffnization.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetToken")]
        [AllowAnonymous]
        public IActionResult GetToken([FromBody] GetTokenModel model)
        {
            string token = string.Empty;

            try
            {
                
                token = GenerateToken(10);
                //if(systemClient != null)
                //{
                //}
                //else
                //{
                //    return Unauthorized("Invalid credentials");
                //}
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Internal error");
                return StatusCode(500, "Internal error");
            }

            return Json(new { Success = true, Token = token });
        }

        private string GenerateToken(int systemClientId)
        {

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, systemClientId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, systemClientId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
