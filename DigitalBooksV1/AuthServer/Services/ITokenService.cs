using Author.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Services
{
    public interface ITokenService
    {
        bool ValidateUser(User users);
        //ActionResult<string> BuildToken(string v1, string v2, string[] strings, string? userName);
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName);
    }
}