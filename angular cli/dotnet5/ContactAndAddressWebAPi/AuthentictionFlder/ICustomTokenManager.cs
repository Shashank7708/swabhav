using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAddressCore.Model;
using ContactAndAddressWebAPi.DtoModel;

namespace ContactAndAddressWebAPi.AuthentictionFlder
{
   public interface ICustomTokenManager
    {
        dtoValidateUsercs CreateToken(User user,Guid tenentId);
        string GetUserInfoByToken(string token);
        bool VerifyToken(string token);
    }
}
