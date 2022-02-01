using Metrics.Data.Requests;
using MetricsManager.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly IMetricsAgentClient _metricsAgentClient;

        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger,
            IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom {fromTime}-{toTime}");

            var response = await _metricsAgentClient.GetNetworkMetrics(new NetworkMetricsRequest
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"recived: {response?.Metrics?.Count}");

            return Ok();
        }
    }
}
