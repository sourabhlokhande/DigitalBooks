using Author.Data;
using Author.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServer.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthorDbContext _dbContext;
        public TokenService(AuthorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool ValidateUser(User users)
        {
            User userObj = _dbContext.UserTbl.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password);
            if (userObj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
        };

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
