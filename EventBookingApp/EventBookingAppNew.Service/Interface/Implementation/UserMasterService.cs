using Event_Booking_AppCore;
using EventBookingAppNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public class UserMasterService : IUserMasterService
    {
        private readonly IUserMasterRepository _userRepository;
        public UserMasterService(IUserMasterRepository usermasterRepo)
        {
            _userRepository = usermasterRepo;
        }
        bool IUserMasterService.DeleteUser(UserMaster userMaster)
        {
            return  _userRepository.DeleteUser(userMaster);

        }

        bool IUserMasterService.EditUser(UserMaster userMaster)
        {
            return  _userRepository.EditUser(userMaster);
        }

        async Task<UserMaster> IUserMasterService.GetUserBasedOnId(int id)
        {
            return await _userRepository.GetUserBasedOnId(id);
        }

        async Task<IEnumerable<UserMaster>> IUserMasterService.GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        Task IUserMasterService.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
