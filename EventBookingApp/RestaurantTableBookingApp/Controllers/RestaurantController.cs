using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantTableBookingApp.Core.ViewModels;
using RestaurantTableBookingApp.Service.Interface;
using System.Threading.Tasks;

namespace RestaurantTableBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService=restaurantService;
        }
        [HttpGet("restaurants")]
        public async Task<ActionResult> GetAllRestaurants()
        {
            var result = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(result);
        }
        [HttpGet("branches/{restaurantId}")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<RestaurantBranchModel>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetRestaurantsBasedOnBranchId(int restaurantId)
        {
            var result = await _restaurantService.GetRestaurantsBranchsByRestaurantIdAsync(restaurantId);
            if(result==null || !result.Any())
            {
                return NotFound(); 
            }
            return Ok(result);
        }
        [HttpGet("diningtables/{branchId}")]
        public async Task<ActionResult<IEnumerable<DiningTableWithTimeSlotsModel>>> GetDiningTablesByBranchAsync(int branchId)
        {
            var diningTables=await _restaurantService.GetDiningTableByBranch(branchId);
            if (diningTables == null || !diningTables.Any())
            {
                return NotFound();
            }
            return Ok(diningTables);
        }
        [HttpGet("diningtables/{branchId}/{date}")]
        public async Task<ActionResult> GetDiningTablesByBranchAndDateAsync(int branchId,DateTime date)
        {
            var diningTables = await _restaurantService.GetDiningTableByBranchAsync(branchId,date);
            if (diningTables == null || !diningTables.Any())
            {
                return NotFound();
            }
            return Ok(diningTables);
        }
    }
}
