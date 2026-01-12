using EventManagementWebApi.Data;
using EventManagementWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventMasterController : ControllerBase
    {
        private IGenericRepository<EventMaster> _repository;
        private readonly IAppLogger _logger;
        public EventMasterController(IGenericRepository<EventMaster> repository, IAppLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetEventsAsync")]
        public async Task<ActionResult<IEnumerable<EventMaster>>> GetEventsAsync()
        {
            try { 
                var results = await _repository.GetAllAsync();
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
        [Route("GetEventAsync/{id}")]
        public async Task<ActionResult<EventMaster>> GetEventAsync(Guid id)
        {
            try { 
                var results = await _repository.GetAsyncBasedOnId(filter:x=>x.id==id);
                if (results?.id!=Guid.Empty)
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
        [Route("AddEventAsync")]
        public async Task<ActionResult<EventMaster>> AddEventAsync(EventMaster obj)
        {
            try
            {
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
        [Route("DeleteEventAsync/{id}")]
        public async Task<ActionResult<bool>> DeleteEventAsync(Guid id)
        {
            try { 
                var eventObj = await _repository.GetAsyncBasedOnId(filter: x => x.id == id);
                if (eventObj == null)
                    return BadRequest("Something went wrong");

                var results = _repository.Delete(eventObj);
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
        [Route("UpdateEvent/{id}")]
        public async Task<ActionResult<bool>> UpdateEvent(Guid id, EventMaster obj)
        {
            try
            {
                var eventObj = await _repository.GetAsyncBasedOnId(filter: x=>x.id==id);
                if (eventObj == null)
                    return BadRequest("Something went wrong");
                eventObj.Title = obj.Title;
                eventObj.IsActive = obj.IsActive;
                var results = _repository.Update(eventObj);
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
