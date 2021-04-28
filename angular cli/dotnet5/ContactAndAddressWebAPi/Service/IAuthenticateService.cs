using ContactAddressCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAndAddressWebAPi.Service
{
   public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);
    }
}
