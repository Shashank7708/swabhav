using Event_Booking_AppCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public class UserMasterRepository :IUserMasterRepository
    {
        private readonly MyDbContext _context;

        public UserMasterRepository(MyDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> AddUser(UserMaster userMaster)
        {
           await _context.userMaster.AddAsync(userMaster);
            return true;
        }
        public async Task<UserMaster> GetUserBasedOnUserName(string emailId)
        {
            var userMaster = await _context.userMaster.FirstOrDefaultAsync(x => x.EmailId == emailId);
            if(userMaster== null)
            {
                return null;
            }
            return userMaster;
        }

        bool IUserMasterRepository.DeleteUser(UserMaster master)
        {
            _context.userMaster.Remove(master);
            return true;
        }

        bool IUserMasterRepository.EditUser(UserMaster userMaster)
        {
            _context.userMaster.Update(userMaster);
            return true;
        }

        async Task<UserMaster> IUserMasterRepository.GetUserBasedOnId(int id)
        {
            var userMaster = await _context.userMaster.FirstOrDefaultAsync(x => x.Id == id);
            return userMaster;
        }

        async Task<IEnumerable<UserMaster>> IUserMasterRepository.GetUsers()
        {
            try
            {
                var items = await _context.userMaster.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
