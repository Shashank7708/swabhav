using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public interface IUserMasterRepository
    {
        Task<IEnumerable<UserMaster>> GetUsers();
        Task<UserMaster> GetUserBasedOnId(int id);
        Task<UserMaster> GetUserBasedOnUserName(string emailId);
        bool EditUser(UserMaster userMaster);
        bool DeleteUser(UserMaster userMaster);
        Task<bool> AddUser(UserMaster userMaster);
        Task SaveChangesAsync();
    }
}
