using RestaurantTableBookingApp.Core.ViewModels;
using RestaurantTableBookingApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Service.Interface
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantrepository)
        {
            this._restaurantRepository = restaurantrepository;
        }
        public async Task<IEnumerable<RestaurantModel>> GetAllRestaurantsAsync()
        {
           return await _restaurantRepository.GetAllRestaurantsAsync();
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantsBranchsByRestaurantIdAsync(int restaurantId)
        {
            return await _restaurantRepository.GetRestaurantsBranchsByRestaurantIdAsync(restaurantId);
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranch(int branchId)
        {
            return await _restaurantRepository.GetDiningTableByBranch(branchId);
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotsModel>> GetDiningTableByBranchAsync(int branchId, DateTime date)
        {
            return await _restaurantRepository.GetDiningTableByBranchAsync(branchId, date);
        }
    }
}
