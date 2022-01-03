using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.Controllers
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

        private static readonly List<WeatherForecast> _repository = new();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _repository.ToArray();
        }

        /// <summary>
        /// Возможность сохранить температуру в указанное время
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost("save-temperature")]
        public IActionResult SaveTemperature([FromQuery]int temperature, [FromBody]DateTime date)
        {
            _logger.LogInformation("save-temperature!");

            if (temperature < -99)
                return Problem("Temperature is low");
            _repository.Add(new WeatherForecast
            {
                Date = date,
                TemperatureC = temperature
            });
       
            return Ok("Saved");
        }

        /// <summary>
        /// Возможность отредактировать показатель температуры в указанное время
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPatch("edit-temperature")]
        public IActionResult EditTemperature([FromForm]int temperature, [FromForm]DateTime date)
        {
            var old = _repository.FirstOrDefault(i => i.Date == date);
            if (old == null)
                return Problem("Before execute saving method");
            old.TemperatureC = temperature;

            return Ok("Temperature edited");
        }

        /// <summary>
        /// Возможность удалить показатель температуры в указанный промежуток времени
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpDelete("delete-temperature")]
        public IActionResult DeleteTemperature([FromForm] DateTime startDate, [FromForm] DateTime endDate)
        {
            var count = _repository.RemoveAll(i => i.Date >= startDate && i.Date < endDate);
            if (count == 0)
                return Problem("Nothing to delete");
            return Ok($"Removed {count} elements");
        }

        /// <summary>
        /// Возможность прочитать список показателей температуры за указанный промежуток времени
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("get-temperature-list")]
        public IActionResult GetTemperatureList([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return Ok(_repository.Where(i => i.Date >= startDate && i.Date < endDate).ToArray());
        }
    }
}
