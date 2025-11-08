using AuthenticationAndAuthorization.Entities;
using AuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationAndAuthorization.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _config;
        public AuthService(MyDbContext context, IConfiguration config)
        {
            this._context = context;
            this._config = config;
        }
        public async Task<LoginResponse> Login(UserDto request)
        {
            var loginResponseDto = new LoginResponse();
            var loginMaster = await _context.LoginMaster.FirstOrDefaultAsync(x => x.username == request.Username);
            if (string.IsNullOrEmpty(loginMaster?.username))
                return new LoginResponse();
            if (new PasswordHasher<LoginMaster>().VerifyHashedPassword(loginMaster, loginMaster.pwd, request.Password) == PasswordVerificationResult.Failed)
                return new LoginResponse();

            loginResponseDto.RefreshToken = GenerateAndSaveRefreshToken(loginMaster.id);
            loginResponseDto.Token = CreateToken(loginMaster);
          //  string token = CreateToken(loginMaster);
            return loginResponseDto;
        }

        private string CreateToken(LoginMaster login)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,login.username),
                new Claim(ClaimTypes.NameIdentifier,login.id.ToString()),
                new Claim(ClaimTypes.Role,login.role.ToString())
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

        private string GenerateAndSaveRefreshToken(int userId)
        {
            
            var list=_context.UserRefreshToken.Where(x=>x.UserId==userId).ToList();
            var refreshToken = GenerateRefreshToken();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.RemoveRange(list);

                UserRefreshToken obj =
                    new UserRefreshToken()
                    {
                        UserId = userId,
                        Referesh_Token = refreshToken,
                        Expiry = DateTime.UtcNow.AddDays(1)
                    };
                _context.UserRefreshToken.Add(obj);
                _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
            }
            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public string ValidateAndGenerateTokenAfterTokenExpiresButValidRefreshToken(string token)
        {
            var responseObj = new LoginResponse();
            var obj = ValidateRefereshToken(token);
            var loginMaster = _context.LoginMaster.Find(obj.id);
            if (obj != null)
            {
                
                return CreateToken(loginMaster);
            }
            return null;
        }
        private UserRefreshToken ValidateRefereshToken(string token)
        {
            var obj = _context.UserRefreshToken.FirstOrDefault(x => x.Referesh_Token == token);
            if (obj is null || obj.Expiry >= DateTime.UtcNow)
                return null;
            return obj;
        }


        public async Task<LoginMaster> Register(UserDto request)
        {
            LoginMaster loginMaster = new LoginMaster();

            var hashedPassword = new PasswordHasher<LoginMaster>()
                .HashPassword(loginMaster, request.Password);

            loginMaster.username = request.Username;
            loginMaster.pwd = hashedPassword;
            loginMaster.CreatedBy = "Admin";
            loginMaster.CreatedOn = DateTime.Now;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.LoginMaster.AddAsync(loginMaster);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return loginMaster;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new LoginMaster();
            }
        }
    }
}
