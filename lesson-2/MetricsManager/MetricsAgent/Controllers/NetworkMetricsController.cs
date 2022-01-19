using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            return Ok();
        }
    }
}
