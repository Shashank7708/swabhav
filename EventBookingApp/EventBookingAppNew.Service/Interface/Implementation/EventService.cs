using Event_Booking_AppCore;
using EventBookingAppNew.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        bool IEventService.DeleteEvent(EventMaster eventMaster)
        {
            return _eventRepository.DeleteEvent(eventMaster);
        }

        async Task<bool> IEventService.EditEvent(EventMasterViewModel reqObj)
        {
            var eventMaster = await _eventRepository.GetEventBasedOnId(reqObj.id);
            if (eventMaster is null || eventMaster.Title is null)
            {
                return false;
            }
            eventMaster.Title = reqObj.title;
            eventMaster.Description = reqObj.description;
            eventMaster.StartDate = reqObj.startDate;
            eventMaster.EndDate = reqObj.endDate;
            eventMaster.VenueName = reqObj.venueName;
            eventMaster.Capacity = reqObj.capacity;
            eventMaster.ImageUrl = reqObj.imageUrl;
            //eventMaster.CreatedOn = reqObj.createdOn;
            //eventMaster.CreatedBy = reqObj.createdBy;

            return  _eventRepository.EditEvent(eventMaster);
        }
        bool IEventService.AddEvent(EventMasterViewModel reqObj)
        {
            var eventMaster = new EventMaster();
            eventMaster.Title = reqObj.title;
            eventMaster.Description = reqObj.description;
            eventMaster.StartDate = reqObj.startDate;
            eventMaster.EndDate = reqObj.endDate;
            eventMaster.VenueName = reqObj.venueName;
            eventMaster.Capacity = reqObj.capacity;
            eventMaster.ImageUrl = reqObj.imageUrl;
            eventMaster.CreatedOn = reqObj.createdOn;
            eventMaster.CreatedBy = reqObj.createdBy;

            return _eventRepository.AddEvent(eventMaster);
        }

        async Task<EventMaster> IEventService.GetEventBasedOnId(Guid id)
        {
            return await _eventRepository.GetEventBasedOnId(id);
        }

        async Task<IEnumerable<EventMaster>> IEventService.GetEvents()
        {
            return await _eventRepository.GetEvents();
        }

        async Task IEventService.SaveChangesAsync()
        {
             await _eventRepository.SaveChangesAsync();
        }
    }
}
