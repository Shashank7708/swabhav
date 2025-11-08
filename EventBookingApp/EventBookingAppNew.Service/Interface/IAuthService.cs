using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public interface IAuthService
    {
        Task<UserMaster> Register(UserRegisterDto request);
        Task<LoginResponse> Login(UserLoginDto request);
    }
}
