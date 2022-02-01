using Metrics.Data.Requests;
using MetricsManager.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IMetricsAgentClient _metricsAgentClient;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetErrorsCountFrom {fromTime}-{toTime}");

            var response = await _metricsAgentClient.GetDonNetMetrics(new DotNetMetricsRequest
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"recived: {response?.Metrics?.Count}");

            return Ok();
        }
    }
}
