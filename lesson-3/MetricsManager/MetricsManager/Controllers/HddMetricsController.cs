using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsManager.Controllers
{
    //api/metrics/hdd/left/from/{fromTime}/to/{toTime}/
    //(размер оставшегося свободного дискового пространства в мегабайтах)

    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddMetricsController : Controller
    {
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController(ILogger<HddMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetLeftFrom {fromTime}-{toTime}");
            return Ok();
        }
    }
}
