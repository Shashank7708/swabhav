using AuthenticationAndAuthorization.Entities;
using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace AuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService,IConfiguration config)
        {
            this._authService = authService;
            this._config = config;
        }
        
        
        [HttpPost("register")]
        public async Task<ActionResult<LoginMaster>> Register([FromBody]UserDto request)
        {
            if (ModelState.IsValid)
            {
                var result=await _authService.Register(request);
                if(!String.IsNullOrEmpty(result.username))
                    return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(UserDto request)
        {
            if (ModelState.IsValid)
            {
                return await _authService.Login(request);
                
            }
            return BadRequest();
        }

        [HttpGet("GetAccessToken")]
        public async Task<ActionResult<string>> ValidateAndGenerateTokenAfterTokenExpiresButValidRefreshToken(string token)
        {
            return Ok(ValidateAndGenerateTokenAfterTokenExpiresButValidRefreshToken(token));
        }


        [HttpGet("OnlyAuthenticated")]
        [Authorize]
        public ActionResult GetDUmmyString()
        {
            return Ok("Hello world");
        }
  
        
    }
}
