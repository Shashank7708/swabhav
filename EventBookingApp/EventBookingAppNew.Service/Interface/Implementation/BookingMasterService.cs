using Event_Booking_AppCore;
using EventBookingAppNew.Data;
using EventBookingAppNew.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingAppNew.Services
{
    public class BookingMasterService : IBookingMasterService
    {
        private readonly IBookingRepository _bookingMasterRepository;
        private readonly MyDbContext _context;
        public BookingMasterService(IBookingRepository bookingRepository,MyDbContext myDbContext)
        {
            this._bookingMasterRepository = bookingRepository;
            _context = myDbContext;
        }
        public bool DeleteBookingMaster(BookingMaster master)
        {
            return _bookingMasterRepository.DeleteBookingMaster(master);
        }

        public bool EditBookingMaster(BookingMaster bookingMaster)
        {
            return _bookingMasterRepository.EditBookingMaster(bookingMaster);
        }

        public async Task<BookingMaster> GetBookingBasedOnId(int id)
        {
            return await _bookingMasterRepository.GetBookingBasedOnId(id);
        }

        public async Task<IEnumerable<BookingMaster>> GetBookings(Guid id)
        {
            return await _bookingMasterRepository.GetBookings();
        }
        public async Task<IEnumerable<BookingMasterViewModel>> GetBookingsBasedOnEventId(Guid id)
        {
            return await  _bookingMasterRepository.GetBookingsBasedOnEventId(id);
        }

        public async Task SaveChangesAsync()
        {
             await _bookingMasterRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<EventBookingViewModel>> GetBookingBasedOnUserId(int userId)
        {
            return await _bookingMasterRepository.GetBookingBasedOnUserId(userId);
        }

        public async Task<bool> AddBookingRange(List<ConfirmBookingRequest> confirmBookingRequests)
        {
            var bookingMasterList= new List<BookingMaster>();
       
            foreach(var i in confirmBookingRequests)
            {
                var obj = new BookingMaster();
                obj.UserId=i.UserId;
                obj.EventId=i.EventId;
                obj.Status=i.Status;
                obj.CreatedBy = i.UserName;
                obj.CreatedOn = i.CreatedOn;
                bookingMasterList.Add(obj);
            }
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result =await _bookingMasterRepository.GetBookingsForOperations(confirmBookingRequests.First().UserId);
                if (result != null && result.Any()) 
                {
                    foreach (var i in result)
                    {
                       var deleteResponse= _bookingMasterRepository.DeleteBookingMaster(i);
                        if (deleteResponse == false)
                            throw new Exception();
                    } 
                }
                await _bookingMasterRepository.AddBookingRange(bookingMasterList);
                await _bookingMasterRepository.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                return false;
            }

        }
    }
}
