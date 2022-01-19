using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsAgent.Controllers
{
    //api/metrics/hdd/left/from/{fromTime}/to/{toTime}/
    //(размер оставшегося свободного дискового пространства в мегабайтах)

    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddMetricsController : Controller
    {
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
