using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public interface IBookingMasterService
    {
        Task<IEnumerable<BookingMaster>> GetBookings(Guid id);
        //Task<BookingMaster> GetBookingBasedOnId(Guid id);
        Task<IEnumerable<BookingMasterViewModel>> GetBookingsBasedOnEventId(Guid id);
        Task<IEnumerable<EventBookingViewModel>> GetBookingBasedOnUserId(int userId);
        Task<bool> AddBookingRange(List<ConfirmBookingRequest> confirmBookingRequests);
        bool EditBookingMaster(BookingMaster userMaster);
        bool DeleteBookingMaster(BookingMaster master);
        Task SaveChangesAsync();
    }
}
