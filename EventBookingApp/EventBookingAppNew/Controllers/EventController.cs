using Event_Booking_AppCore;
using EventBookingAppNew.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventBookingAppNew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }
        [HttpGet("GetEvents")]
        public async Task<ActionResult> GetEvents()
        {
            var result =await _eventService.GetEvents();
            if (result == null || !result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("GetEventOnId/{id}")]
        public async Task<ActionResult> GetEventOnId(Guid id)
        {
            var result =await _eventService.GetEventBasedOnId(id);
            if (result == null || result.Title==null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(EventMasterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result=_eventService.AddEvent(obj);
                await _eventService.SaveChangesAsync();
                return Ok(result);
            }
            return BadRequest("something went wrong");
        }
        [HttpPut]
        public async Task<ActionResult> EditEvent(EventMasterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result=await _eventService.EditEvent(obj);
                await _eventService.SaveChangesAsync();
                return Ok(result);
            }
            return BadRequest("something went wrong");
        }
    }
}
