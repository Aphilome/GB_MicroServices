using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    //api/metrics/ram/available/from/{fromTime}/to/{toTime}/
    //(размер свободной оперативной памяти в мегабайтах)

    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : Controller
    {
        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsController(ILogger<RamMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsAvailableFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsAvailableFrom {fromTime}-{toTime}");
            return Ok();
        }
    }
}
