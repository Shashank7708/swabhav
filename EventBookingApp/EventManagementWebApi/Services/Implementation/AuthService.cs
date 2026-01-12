using EventManagementWebApi.Data;
using EventManagementWebApi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManagementWebApi.Services.Implementation
{
    public class AuthService:IAuthService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(MyDbContext context, IConfiguration config)
        {
            this._context = context;
            this._config = config;
        }
        public async Task<UserMaster> Register(UserDto request)
        {
            var userMaster = new UserMaster();

            var hashedPassword = new PasswordHasher<UserMaster>()
                .HashPassword(userMaster, request.Password);

            userMaster.username = request.Username;
            userMaster.pwd = hashedPassword;
            userMaster.CreatedBy = "Admin";
            userMaster.CreatedOn = DateTime.Now;
            userMaster.role = request.Role;
            userMaster.Name=request.Name;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.userMaster.Add(userMaster);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return userMaster;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new UserMaster();
            }
        }
        public async Task<LoginResponse> Login(UserDto request)
        {
            try
            {
                var loginResponseDto = new LoginResponse();
               // var abc = _context.userMaster.ToList();
                var userMaster = await _context.userMaster.FirstOrDefaultAsync(x => x.username == request.Username);
                if (string.IsNullOrEmpty(userMaster?.username))
                    return new LoginResponse();
                if (new PasswordHasher<UserMaster>().VerifyHashedPassword(userMaster, userMaster.pwd, request.Password) == PasswordVerificationResult.Failed)
                    return new LoginResponse();

                //loginResponseDto.RefreshToken = GenerateAndSaveRefreshToken(loginMaster.id);
                loginResponseDto.Token = CreateToken(userMaster);
                //  string token = CreateToken(loginMaster);
                return loginResponseDto;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private string CreateToken(UserMaster user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.username),
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                new Claim(ClaimTypes.Role,user.role?.ToString())
            };
            var key = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_config.GetValue<string>("JWT:key")!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config.GetValue<string>("JWT:issuer"),
                audience: _config.GetValue<string>("JWT:audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
