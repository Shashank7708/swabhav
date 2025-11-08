namespace EventManagementWebApi.Dto
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; }
        public string Password { get; set; } = string.Empty;
        public string IsActive { get; set; }
        public string Role { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; }
       // public string RefreshToken { get; set; }
    }
    public enum RolesEnum
    {
        Admin,
        Audience,
        User

    }
}
