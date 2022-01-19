using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsManager.Controllers
{
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        
        public IActionResult GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
