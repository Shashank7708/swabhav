using Event_Booking_AppCore;
using EventBookingAppNew.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAppNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        //private readonly IAppLogger _logger;
        public AuthController(IAuthService authService, IConfiguration config)//, IAppLogger logger)
        {
            this._authService = authService;
            this._config = config;
            //_logger = logger;
        }
        [HttpPost]
        [Route("RegisterUserAsync")]
        public async Task<ActionResult<UserMaster>> AddUserAsync(UserRegisterDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = await _authService.Register(obj); //StoringHashedPassword
                    if (result!=null && !String.IsNullOrEmpty(result.FullName))
                        return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                //_logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(UserLoginDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // _logger.ActivityLog($"User {request.Username} logged into system");
                    return await _authService.Login(request);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
               // _logger.ExceptionLog(ex, $"Exception occurred in Login {request.Username}| {ex.Message} | {ex.StackTrace}");
                return BadRequest();
            }
        }
    }
}

