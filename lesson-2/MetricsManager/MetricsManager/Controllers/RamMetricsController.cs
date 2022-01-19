using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsManager.Controllers
{
    //api/metrics/ram/available/from/{fromTime}/to/{toTime}/
    //(размер свободной оперативной памяти в мегабайтах)

    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : Controller
    {
        [HttpGet("agent/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsAvailableFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
