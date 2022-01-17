using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{

    //api/metrics/cpu/from/{fromTime}/to/{toTime}/
    //https://localhost:5001/api/metrics/cpu/from/21.12.2020/to/30.12.2020/

    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : Controller
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom([FromRoute]DateTime fromTime, [FromRoute]DateTime toTime)
        {
            return Ok();
        }
    }
}
