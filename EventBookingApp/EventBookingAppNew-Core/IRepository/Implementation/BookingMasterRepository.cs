using Event_Booking_AppCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Data
{
    public class BookingMasterRepository:IBookingRepository
    {
        private readonly MyDbContext _context;

        public BookingMasterRepository(MyDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> AddBookingRange(List<BookingMaster> bookingMasters)
        {
            await _context.AddRangeAsync(bookingMasters);
            
            return true;
        }


        public bool EditBookingMaster(BookingMaster master)
        {
             _context.BookingMaster.Update(master);
            return true;
        }

        public async Task<BookingMaster> GetBookingBasedOnId(int id)
        {
            var result = await _context.BookingMaster.Where(x=>x.id==id).SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<BookingMaster>> GetBookings()
        {
            var result = await _context.BookingMaster.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<BookingMasterViewModel>> GetBookingsBasedOnEventId(Guid id)
        {
            var result = await _context.BookingMaster.Include(x => x.EventMaster).Where(x => x.EventId.Equals(id)).Select(x => new BookingMasterViewModel
            {
                id = x.id,
                UserId = x.UserId,
                EventId = x.EventId,
                Status = x.Status,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                EventName = x.EventMaster.Title
            }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<EventBookingViewModel>> GetBookingBasedOnUserId( int userId)
        {
            var result = await _context.BookingMaster.Where(x => x.UserId == userId).Include(x=>x.EventMaster).Select(x =>
            new EventBookingViewModel
            {
                BookingId = x.id,
                EventId = x.EventId,
                UserId = x.UserId,
                Status = x.Status,
                EventTitle=x.EventMaster.Title,
                EventDescription=x.EventMaster.Description,
                EventStartDate=x.EventMaster.StartDate,
                EventEndDate=x.EventMaster.EndDate,
                EventPrice=x.EventMaster.Price,
                EventVenue=x.EventMaster.VenueName
            }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BookingMaster>> GetBookingsForOperations(int userId)
        {
            var result = await _context.BookingMaster.Where(x => x.UserId == userId).ToListAsync();
            return result;
        }
        public bool DeleteBookingMaster(BookingMaster bookingMaster)
        {
            try
            {
                _context.BookingMaster.Remove(bookingMaster);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }
    }
}
