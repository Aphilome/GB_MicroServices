using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsManager.Controllers
{
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
