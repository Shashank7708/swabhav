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

namespace ContactAndAddressWebAPi.Service
{
    public class Authenticateservice
    {
       /*

        public readonly AppSettings _appSettings;
        public readonly IContactRepository _db;
        public Authenticateservice(IOptions<AppSettings> appSettings,IContactRepository db)
        {
            _appSettings = appSettings.Value;
            this._db = db;
        }

       
        public User Authenticate(string userName, string password)
        {
            var user = this._db.ValidateUser(userName, password);
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
            
            user.Password = null;
            return user;
        }
       */
    }

}
