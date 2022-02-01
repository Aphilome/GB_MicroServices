using Metrics.Data.Requests;
using MetricsManager.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{

    //api/metrics/cpu/from/{fromTime}/to/{toTime}/
    //https://localhost:5001/api/metrics/cpu/from/21.12.2020/to/30.12.2020/

    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : Controller
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IMetricsAgentClient _metricsAgentClient;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetMetricsFrom([FromRoute]DateTime fromTime, [FromRoute]DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom with {fromTime}-{toTime}");

            var response = await _metricsAgentClient.GetCpuMetrics(new CpuMetricsRequest
            {
                FromTime = fromTime,
                ToTime = toTime
            });
            _logger.LogInformation($"recived: {response.Metrics?.Count}");

            return Ok();
        }
    }
}
