using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public interface IBookingRepository
    {
        Task<bool> AddBookingRange(List<BookingMaster> bookingMasters);
        Task<IEnumerable<BookingMaster>> GetBookings();
        Task<BookingMaster> GetBookingBasedOnId(int id);
        Task<IEnumerable<BookingMasterViewModel>> GetBookingsBasedOnEventId(Guid id);
        Task<IEnumerable<EventBookingViewModel>> GetBookingBasedOnUserId(int userId);
        bool EditBookingMaster(BookingMaster bookingMaster);
        bool DeleteBookingMaster(BookingMaster master);
        Task<IEnumerable<BookingMaster>> GetBookingsForOperations(int userId);
        Task SaveChangesAsync();
    }
}
