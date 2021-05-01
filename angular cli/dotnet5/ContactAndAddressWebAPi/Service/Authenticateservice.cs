using ContactAddressCore.Model;
using ContactAndAddressWebAPi.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactAndAddressApp_data.Repository;
using ContactAndAddressWebAPi.DtoModel;

namespace ContactAndAddressWebAPi.Service
{
    public class Authenticateservice:IAuthenticateService
    {
       
        public readonly AppSettings _appSettings;
        public readonly IEfRespository<User> _db;
        public Authenticateservice(IOptions<AppSettings> appSettings,IEfRespository<User> db)
        {
            _appSettings = appSettings.Value;
            this._db = db;
        }

       
        public async Task<dtoValidateUsercs> Authenticate(string userName, string password)
        {
            User user =await this._db.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            dtoValidateUsercs dtouser = new dtoValidateUsercs { UserName = user.UserName, Password = user.Password };
            //return null if user not fond;
            if (user == null)
                return null;

            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            dtouser.Token = tokenhandler.WriteToken(token);
            
             dtouser.Password= null;
            return dtouser;
        }
       
    }

}
