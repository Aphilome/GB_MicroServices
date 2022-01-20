using MetricsAgent.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    //api/metrics/cpu/from/{fromTime}/to/{toTime}/
    //https://localhost:5001/api/metrics/cpu/from/21.12.2020/to/30.12.2020/
    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : Controller
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _repository;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger, 
            ICpuMetricsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom([FromRoute]DateTime fromTime, [FromRoute]DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom with {fromTime}-{toTime}");
            return Ok();
        }
    }
}
