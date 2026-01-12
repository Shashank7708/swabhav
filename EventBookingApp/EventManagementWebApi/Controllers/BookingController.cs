using EventManagementWebApi.Data;
using EventManagementWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<BookingMaster> _repository;
        private readonly IAppLogger _logger;
        private readonly MyDbContext _dbContext;
        public BookingController(IGenericRepository<BookingMaster> repository, IAppLogger logger,MyDbContext myDbContext)
        {
            _repository = repository;
            _logger = logger;   
            _dbContext= myDbContext;
        }

        [HttpGet]
        [Route("GetBookingsAsync")]
        public async Task<ActionResult<IEnumerable<UserMaster>>> GetBookingsAsync()
        {
            try { 
                var results = await _repository.GetAllAsync();
                
                var r2=await _dbContext.BookingMaster.Include(x=>x.EventMaster).ToListAsync();
                if (results.Any())
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        [Route("GetBookingAsync")]
        public async Task<ActionResult<BookingMaster>> GetBookingAsyncGetUser(int id)
        {
            try
            {
                var results = await _repository.GetAsyncBasedOnId(filter: x => x.id == id);
                if (results?.id != 0)
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpPut]
        [Route("AddBookingAsync")]
        public async Task<ActionResult<BookingMaster>> AddBookingAsync(BookingMaster obj)
        {
            try { 
                var results = await _repository.AddAsync(obj);
                if (results)
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }

        }
        [HttpGet]
        [Route("DeleteBooking/{id}")]
        public async Task<ActionResult<bool>> DeleteBooking(int id)
        {
            try { 
                var bookingObj = await _repository.GetAsyncBasedOnId(filter: x => x.id == id);
                if (bookingObj == null)
                    return BadRequest("Something went wrong");

                var results = _repository.Delete(bookingObj);
                await _repository.SaveChangesAsycn();
                if (results)
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpPut]
        [Route("UpdateBooking/{id}")]
        public async Task<ActionResult<bool>> UpdateBooking(int id, BookingMaster obj)
        {
            try { 
                var bookingObj = await _repository.GetAsyncBasedOnId(filter: x=>x.id==id);
                if (bookingObj == null)
                    return BadRequest("Something went wrong");
                bookingObj.Status = obj.Status;
                var results = _repository.Update(bookingObj);
                await _repository.SaveChangesAsycn();
                if (results)
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
    }
}
