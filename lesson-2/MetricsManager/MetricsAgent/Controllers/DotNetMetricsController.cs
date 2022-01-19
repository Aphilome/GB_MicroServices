using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsAgent.Controllers
{
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        
        public IActionResult GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
