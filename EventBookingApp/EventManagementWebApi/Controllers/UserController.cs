using EventManagementWebApi.Data;
using EventManagementWebApi.Data.Implementation;
using EventManagementWebApi.Dto;
using EventManagementWebApi.Services;
using EventManagementWebApi.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepository<UserMaster> _repository;
        private IAuthService _authService;
        private readonly IAppLogger _logger;
        public UserController(IGenericRepository<UserMaster> repository, IAppLogger logger, IAuthService service) 
        {
            _repository = repository;
            _logger = logger;
            _authService = service;

        }


        [HttpGet]
        [Route("GetUserAsync")]
        public async Task<ActionResult<IEnumerable<UserMaster>>> GetUserAsync()
        {
            try
            {
                var results = await _repository.GetAllAsync();
                _logger.ActivityLog($"Getting All Users for ");//Get Current Logged user from User.Identity.Name
                if (results.Any())
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch(Exception ex)
            {
                _logger.ExceptionLog(ex,"There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<ActionResult<UserMaster>> GetUser( int id)
        {
            try
            {
                var results = await _repository.GetAsyncBasedOnId( filter: x=>x.id==id);
                if (results?.id!=0)
                    return Ok(results);
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost]
        [Route("AddUserAsync")]
        public async Task<ActionResult<UserMaster>> AddUserAsync(UserDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _authService.Register(obj); //StoringHashedPassword
                    if (!String.IsNullOrEmpty(result.username))
                        return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.ExceptionLog(ex, "There is an exception");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        [Route("DeleteUserAsync/{id}")]
        public  async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try { 
                var userObj = await _repository.GetAsyncBasedOnId(filter :x=>x.id==id);
                if (userObj == null)
                    return BadRequest("Something went wrong");

                var results =  _repository.Delete(userObj);
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
        [Route("UpdateUser/{id}")]
        public async Task<ActionResult<bool>> UpdateUser(int id, UserMaster obj)
        {
            try { 
                var userObj = await _repository.GetAsyncBasedOnId(filter:x=>x.id==id);
                if (userObj == null)
                    return BadRequest("Something went wrong");
                userObj.Name=obj.Name;
                userObj.IsActive=obj.IsActive;
                userObj.username = obj.username;
                userObj.pwd=obj.pwd;
                userObj.role=obj.role;
                var results = _repository.Update(userObj);
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
