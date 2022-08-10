using Author.Models;
using AuthServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("api/Auth")]
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

        [HttpPost("Validate")]
        public ActionResult<string> Validate(User users)
        {


            if (_tokenService.ValidateUser(users))
            {
                return _tokenService.BuildToken(_configuration["Jwt:Key"],
                                            _configuration["Jwt:Issuer"],
                                            new[]
                                            {
                                                        _configuration["Jwt:Aud1"],
                                                        _configuration["Jwt:Aud2"]
                                                    },
                                            users.UserName);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
