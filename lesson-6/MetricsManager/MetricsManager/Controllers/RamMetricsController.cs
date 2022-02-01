using Metrics.Data.Requests;
using MetricsManager.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    //api/metrics/ram/available/from/{fromTime}/to/{toTime}/
    //(размер свободной оперативной памяти в мегабайтах)

    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : Controller
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly IMetricsAgentClient _metricsAgentClient;

        public RamMetricsController(
            ILogger<RamMetricsController> logger,
            IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent/available/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetMetricsAvailableFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsAvailableFrom {fromTime}-{toTime}");

            var response = await _metricsAgentClient.GetRamMetrics(new RamMetricsRequest
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"recived: {response?.Metrics?.Count}");

            return Ok();
        }
    }
}
