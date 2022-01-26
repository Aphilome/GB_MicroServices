using AutoMapper;
using Metrics.Data.Dto;
using Metrics.Data.Entity;
using Metrics.Data.Responses;
using MetricsAgent.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
        private readonly IMapper _mapper;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger, 
            ICpuMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<CpuMetric> metrics = _repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }
            return Ok(response);
        }   

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom([FromRoute]DateTime fromTime, [FromRoute]DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom with {fromTime}-{toTime}");
            return Ok();
        }
    }
}
