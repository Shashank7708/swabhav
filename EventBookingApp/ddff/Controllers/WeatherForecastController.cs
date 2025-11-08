using Microsoft.AspNetCore.Mvc;

namespace ddff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyDbContext _dbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,MyDbContext _context)
        {
            _logger = logger;
            _dbContext= _context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
           return Ok(_dbContext.BookingMaster.ToList());
        }
    }
}
