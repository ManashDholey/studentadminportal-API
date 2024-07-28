using Core.Entities.Identity;
using System.Security.Claims;


namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
