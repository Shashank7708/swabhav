using Event_Booking_AppCore;
using EventBookingAppNew.Service;
using EventBookingAppNew.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAppNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingMasterService _bookingService;
        public BookingController(IBookingMasterService bookingService)
        {
            this._bookingService = bookingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingMaster>> GetBookingsAsync(Guid id)
        {

            var result = await _bookingService.GetBookingsBasedOnEventId(id);
            return Ok(result);

        }
        [HttpGet("GetBookingUserId/{id}")]
        public async Task<ActionResult<IEnumerable<EventBookingViewModel>>> GetBookingBasedOnUserId(int id)
        {
            var result = await _bookingService.GetBookingBasedOnUserId(id);
            if (result == null || !result.Any())
                return NoContent();
            return Ok(result);
        }

        [HttpPost("ConfirmBooking")]
        public async Task<ActionResult> UpdateBookingForUserId(List<ConfirmBookingRequest> confirmBookingRequests)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookingService.AddBookingRange(confirmBookingRequests);
                return Ok(result);
            }
            return BadRequest("something went wrong");
        }
    }
}
