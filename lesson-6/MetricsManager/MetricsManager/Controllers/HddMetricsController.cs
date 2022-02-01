using Metrics.Data.Requests;
using MetricsManager.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    //api/metrics/hdd/left/from/{fromTime}/to/{toTime}/
    //(размер оставшегося свободного дискового пространства в мегабайтах)

    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddMetricsController : Controller
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IMetricsAgentClient _metricsAgentClient;

        public HddMetricsController(
            ILogger<HddMetricsController> logger,
            IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent/left/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetLeftFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetLeftFrom {fromTime}-{toTime}");

            var response = await _metricsAgentClient.GetHddMetrics(new HddMetricsRequest
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"recived: {response?.Metrics?.Count}");

            return Ok();
        }
    }
}
