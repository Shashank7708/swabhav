using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public interface IUserMasterService
    {
        Task<IEnumerable<UserMaster>> GetUsers();
        Task<UserMaster> GetUserBasedOnId(int id);
        bool EditUser(UserMaster userMaster);
        bool DeleteUser(UserMaster userMaster);
        Task SaveChangesAsync();
    }
}
