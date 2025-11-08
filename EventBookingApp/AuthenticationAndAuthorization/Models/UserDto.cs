using AuthenticationAndAuthorization.Entities;

namespace AuthenticationAndAuthorization.Models
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;    
        public string Password { get; set; } = string.Empty;
        public RolesEnum Role { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
    
}
