using Microsoft.AspNetCore.Mvc;
using System;

namespace MetricsAgent.Controllers
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
