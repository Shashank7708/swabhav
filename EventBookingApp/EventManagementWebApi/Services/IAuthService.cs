using EventManagementWebApi.Data;
using EventManagementWebApi.Dto;

namespace EventManagementWebApi.Services
{
    public interface IAuthService
    {
        Task<UserMaster> Register(UserDto request);
        Task<LoginResponse> Login(UserDto request);
    }
}
