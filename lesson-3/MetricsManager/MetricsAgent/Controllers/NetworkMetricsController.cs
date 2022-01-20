using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        private readonly ILogger<NetworkMetricsController> _logger;

        public NetworkMetricsController(ILogger<NetworkMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom {fromTime}-{toTime}");
            return Ok();
        }
    }
}
