using AutoMapper;
using Metrics.Data.Dto;
using Metrics.Data.Entity;
using Metrics.Data.Responses;
using MetricsAgent.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsAgent.Controllers
{
    //api/metrics/ram/available/from/{fromTime}/to/{toTime}/
    //(размер свободной оперативной памяти в мегабайтах)

    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : Controller
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly IRamMetricsRepository _repository;
        private readonly IMapper _mapper;

        public RamMetricsController(
            ILogger<RamMetricsController> logger,
            IRamMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"call GetAll");

            IList<RamMetric> metrics = _repository.GetAll();
            var response = GetResponse(metrics);

            return Ok(response);
        }

        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsAvailableFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsAvailableFrom {fromTime}-{toTime}");

            IList<RamMetric> metrics = _repository.GetAll();
            var response = GetResponse(metrics);

            return Ok(response);
        }

        private RamMetricsResponse GetResponse(IList<RamMetric> metrics)
        {
            var response = new RamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
                }
            }

            return response;
        }
    }
}
