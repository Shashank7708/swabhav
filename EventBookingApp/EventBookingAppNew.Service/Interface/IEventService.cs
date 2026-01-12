using Event_Booking_AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public interface IEventService
    {
        Task<IEnumerable<EventMaster>> GetEvents();
        Task<EventMaster> GetEventBasedOnId(Guid id);
        Task<bool> EditEvent(EventMasterViewModel eventMaster);
        bool AddEvent(EventMasterViewModel eventMaster);
        bool DeleteEvent(EventMaster eventMaster);
        Task SaveChangesAsync();
    }
}
