using Microsoft.EntityFrameworkCore;
using RestaurantTableBookingApp.Core;
using RestaurantTableBookingApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Data.Interfaces
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantTableBookingDbContext _dbcontext;
        public RestaurantRepository(RestaurantTableBookingDbContext dbContext) 
        { 
            this._dbcontext=dbContext;
        }
        public async Task<IEnumerable<RestaurantModel>> GetAllRestaurantsAsync()
        {
           var restaurants=await  _dbcontext.Restaurants.OrderBy(x=>x.Name)
                .Select(x => new RestaurantModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Phone=x.Phone,
                    Email=x.Email,
                    ImageUrl=x.ImageUrl,
                }).ToListAsync();

            return restaurants;
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantsBranchsByRestaurantIdAsync( int restaurantId)
        {
            var restaurant = await _dbcontext.RestaurantBranches
                .Where(x => x.RestaurantId == restaurantId)
                .Select(x => new RestaurantBranchModel
                {
                    Id=x.Id,
                    RestaurantId=x.RestaurantId,
                    Name=x.Name,
                    Address=x.Address,
                    Phone=x.Phone,
                    Email=x.Email,
                    ImageUrl=x.ImageUrl
                    
                }).OrderBy(x => x.Name).ToListAsync();
            return restaurant;
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranch(int branchId)
        {   //linq but not lambda expression
            var data = await (
                from rb in _dbcontext.RestaurantBranches
                join dt in _dbcontext.DiningTables on rb.Id equals dt.RestaurantBranchId
                join ts in _dbcontext.TimeSlots on dt.Id equals ts.DiningTableId
                where dt.RestaurantBranchId == branchId && ts.ReservationDay >= DateTime.Now.Date
                orderby ts.Id, ts.MealType
                select new DiningTableWithTimeSlotsModel
                {
                    BranchId = rb.Id,
                    ReservationDay = ts.ReservationDay,
                    MealType = ts.MealType,
                    TableName = dt.SeatName,
                    Capacity = dt.Capacity ?? 0,
                    TableStatus = ts.TableStatus,
                    TimeSlotId = ts.Id,
                }).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranchAsync(int branchId, DateTime date)
        {
            var diningTables = await _dbcontext.DiningTables
                .Where(x => x.RestaurantBranchId == branchId)
                .SelectMany(x => x.TimeSlots, (dt, ts) => new
                {
                    dt.RestaurantBranchId,
                    dt.SeatName,
                    dt.Capacity,
                    ts.ReservationDay,
                    ts.MealType,
                    ts.TableStatus,
                    ts.Id
                })
                .Where(ts => ts.ReservationDay.Date == date.Date)
                .OrderBy(ts => ts.Id)
                .ThenBy(ts => ts.MealType)
                .ToListAsync();
          return  diningTables.Select(x=> new DiningTableWithTimeSlotsModel
          {
            BranchId=x.RestaurantBranchId,
            ReservationDay=x.ReservationDay,
            MealType=x.MealType,
            TableName=x.SeatName,
            Capacity=x.Capacity??0,
            TableStatus=x.TableStatus,
            TimeSlotId=x.Id,
          }).ToList();
        }
    }
}
