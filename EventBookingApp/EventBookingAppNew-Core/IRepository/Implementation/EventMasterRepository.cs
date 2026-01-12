using Event_Booking_AppCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public class EventMasterRepository : IEventRepository
    {
        private readonly MyDbContext _context;
        
        public EventMasterRepository(MyDbContext dbContext)
        {
            _context = dbContext;
        }
        
        bool IEventRepository.DeleteEvent(EventMaster eventMaster)
        {
           _context.EventMaster.Remove(eventMaster);
            return true;
        }
        bool IEventRepository.AddEvent(EventMaster eventMaster)
        {
            _context.EventMaster.Add(eventMaster);
            return true;
        }

        bool IEventRepository.EditEvent(EventMaster eventMaster)
        {
            _context.EventMaster.Update(eventMaster);
            return true;
        }

        async Task<EventMaster> IEventRepository.GetEventBasedOnId(Guid id)
        {
            var eventMaster = await _context.EventMaster.FirstOrDefaultAsync(x=>x.id==id);
            return eventMaster;
        }

        async Task<IEnumerable<EventMaster>> IEventRepository.GetEvents()
        {
            try
            {
                var items = await _context.EventMaster.ToListAsync();
                return items;
            }
            catch(Exception ex)
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
