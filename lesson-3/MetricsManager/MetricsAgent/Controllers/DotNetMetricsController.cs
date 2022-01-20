using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        private readonly ILogger<DotNetMetricsController> _logger;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetErrorsCountFrom {fromTime}-{toTime}");
            return Ok();
        }
    }
}
