using AirlineBookingWebApi.Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AirlineBookingWebApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(AppUser appUser, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
