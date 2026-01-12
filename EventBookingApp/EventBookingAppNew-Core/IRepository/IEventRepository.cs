using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventMaster>> GetEvents();
        Task<EventMaster> GetEventBasedOnId(Guid id);
        bool EditEvent(EventMaster eventMaster);
        bool AddEvent(EventMaster eventMaster);
        bool DeleteEvent(EventMaster eventMaster);
        Task SaveChangesAsync();

    }
}
