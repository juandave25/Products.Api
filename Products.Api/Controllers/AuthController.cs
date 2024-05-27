using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Products.Api.Entities.Auth;
using Products.Api.Services.Interface;

namespace Products.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate user credentials here (this is just an example)
            if (request.Username == "test" && request.Password == "password")
            {
                JwtConfig config = new() { SecretKey = _configuration["Jwt:Key"], Audience = _configuration["Jwt:Audience"], Issuer = _configuration["Jwt:Issuer"], ExpiresInMinutes = int.Parse(_configuration["Jwt:ExpiresInMinutes"]) };
                var token = _tokenService.GenerateToken(request.Username, config);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
