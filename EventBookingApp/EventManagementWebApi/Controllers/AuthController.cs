using EventManagementWebApi.Dto;
using EventManagementWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        private readonly IAppLogger _logger;
        public AuthController(IAuthService authService, IConfiguration config,IAppLogger logger)
        {
            this._authService = authService;
            this._config = config;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(UserDto request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.ActivityLog($"User {request.Username} logged into system");
                    return await _authService.Login(request);

                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                _logger.ExceptionLog(ex,$"Exception occurred in Login {request.Username}| {ex.Message} | {ex.StackTrace}");
                return BadRequest();
            }
        }
    }
}
