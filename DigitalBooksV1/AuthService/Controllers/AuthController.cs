using Author.Data;
using Author.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthorDbContext _dbContext;
        public AuthController(IConfiguration configuration, AuthorDbContext dbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _dbContext = dbContext;
        }

        public class AuthRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authentication(AuthRequestBody authRequestBody)
        {
            var user = ValidateUserCredentials(authRequestBody.UserName, authRequestBody.Password);
            if (user == null)
            {
                return Unauthorized();
            }


            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var signingCredntials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("username", user.UserName));
            claimsForToken.Add(new Claim("usertype", user.UserType));
            claimsForToken.Add(new Claim("created", user.CreatedDate.ToString()));
            claimsForToken.Add(new Claim("modified", user.ModifiedDate.ToString()));


            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
               
                _configuration["Jwt:Audience1"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredntials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private  User ValidateUserCredentials(string? userName, string? password)
        {
            User userObj = _dbContext.UserTbl.First(u => u.UserName == userName && u.Password == password);
            if (userObj != null)
            {
                return userObj;
            }
            else
            {
                return null;
            }
        }
    }
}
