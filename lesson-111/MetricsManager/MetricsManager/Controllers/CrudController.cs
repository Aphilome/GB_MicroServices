using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private List<WeatherForecast> _repository;

        public CrudController()
        {
            _repository = new();
        }

        // Возможность сохранить температуру в указанное время
        [HttpPost("save-temp")]
        public IActionResult SaveTemperature([FromQuery]int temperature, [FromQuery]DateTime dateTime)
        {
            _repository.Add(new WeatherForecast
            {
                Date = dateTime,
                TemperatureC = temperature
            });
            return Ok();
        }
    }
}
