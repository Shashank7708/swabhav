using ContactAddressCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAndAddressWebAPi.DtoModel;
namespace ContactAndAddressWebAPi.Service
{
   public interface IAuthenticateService
    {
        Task<dtoValidateUsercs> Authenticate(string userName, string password);
    }
}
