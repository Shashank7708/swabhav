using ContactAddressCore.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactAndAddressWebAPi.DtoModel;

namespace ContactAndAddressWebAPi.AuthentictionFlder
{
    public class SampleJwtTokenManager : ICustomTokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private readonly IConfiguration configration;
        private byte[] secrectKey;

        public SampleJwtTokenManager(IConfiguration configration)
        {
            this.configration = configration;
            tokenHandler = new JwtSecurityTokenHandler();
            secrectKey = Encoding.ASCII.GetBytes(configration.GetValue<string>("JwtSecrectKey"));
        }

        public dtoValidateUsercs CreateToken(User user,Guid tenentid)
        {
            dtoValidateUsercs dtouser = new dtoValidateUsercs
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role,
                Tenentid=tenentid,
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        // new Claim(ClaimTypes.Name, userName)
                        new Claim("id", dtouser.Id.ToString()),
                        new Claim("username", dtouser.UserName),
                        new Claim("password", dtouser.Password),
                        new Claim("role", dtouser.Role),
                        new Claim("tenentId",dtouser.Tenentid.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(secrectKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            dtouser.Token = tokenHandler.WriteToken(token);
            return dtouser;
        }

        public string GetUserInfoByToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var jwtToken = tokenHandler.ReadToken(token.Replace("\"", string.Empty)) as JwtSecurityToken;
            //  var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name");
            var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "role");
            if (claim != null) return claim.Value;

            return null;
        }

        public bool VerifyToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

            SecurityToken securityToken;

            try
            {
                tokenHandler.ValidateToken(
                token.Replace("\"", string.Empty),
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secrectKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                },
                out securityToken);
            }
            catch (SecurityTokenException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }

            return securityToken != null;
        }
    }
}
