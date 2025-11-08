using AuthenticationAndAuthorization.Entities;
using AuthenticationAndAuthorization.Models;

namespace AuthenticationAndAuthorization.Services
{
    public interface IAuthService
    {
        Task<LoginMaster> Register(UserDto request);
        Task<LoginResponse> Login(UserDto request);
        string ValidateAndGenerateTokenAfterTokenExpiresButValidRefreshToken (string token);
    }
}
