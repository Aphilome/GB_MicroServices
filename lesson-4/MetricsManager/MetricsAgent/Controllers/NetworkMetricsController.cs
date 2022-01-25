using MetricsAgent.DAL.Interfaces;
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
        private readonly INetworkMetricsRepository _repository;

        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger,
            INetworkMetricsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom {fromTime}-{toTime}");
            return Ok();
        }
    }
}
