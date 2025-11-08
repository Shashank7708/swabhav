using Event_Booking_AppCore;
using EventBookingAppNew.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public class AuthService :IAuthService
    {
       // private readonly MyDbContext _context;
        private readonly IConfiguration _config;
        private readonly IUserMasterRepository _userMasterRepository;
        public AuthService(IUserMasterRepository userMasterRepository, IConfiguration config)
        {
            _userMasterRepository = userMasterRepository;
            this._config = config;
        }
        public async Task<UserMaster> Register(UserRegisterDto request)
        {
            var userMaster = new UserMaster();

            var hashedPassword = new PasswordHasher<UserMaster>()
                .HashPassword(userMaster, request.Password);

            userMaster.FullName = request.FullName;
            userMaster.Pwd = hashedPassword;
            userMaster.CreatedBy = "Admin";
            userMaster.CreatedOn = DateTime.Now;
            userMaster.Role = "User";
            userMaster.EmailId = request.EmailId;
            await _userMasterRepository.AddUser(userMaster);
            await _userMasterRepository.SaveChangesAsync();
            return userMaster;
            /* //using var transaction = await _context.Database.BeginTransactionAsync();
             //try
             //{
                 _userMasterRepository.add(userMaster);
                 await _context.SaveChangesAsync();
                 transaction.Commit();
                 return userMaster;
             }
             catch (Exception ex)
             {
                 await transaction.RollbackAsync();
                 return new UserMaster();
             }
     */

        }
        public async Task<LoginResponse> Login(UserLoginDto request)
        {
            try
            {
                var loginResponseDto = new LoginResponse();
                // var abc = _context.userMaster.ToList();
                var userMaster = await _userMasterRepository.GetUserBasedOnUserName(request.EmailId);
                if (string.IsNullOrEmpty(userMaster?.EmailId))
                    return new LoginResponse();
                if (new PasswordHasher<UserMaster>().VerifyHashedPassword(userMaster, userMaster.Pwd, request.Password) == PasswordVerificationResult.Failed)
                    return new LoginResponse();

                //loginResponseDto.RefreshToken = GenerateAndSaveRefreshToken(loginMaster.id);
                loginResponseDto.Token = CreateToken(userMaster);
                loginResponseDto.Username = userMaster.FullName;
                loginResponseDto.Role = userMaster.Role;
                loginResponseDto.UserId = userMaster.Id;
                //  string token = CreateToken(loginMaster);
                return loginResponseDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private string CreateToken(UserMaster user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.EmailId),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role)
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
