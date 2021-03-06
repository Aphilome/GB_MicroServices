using AutoMapper;
using Metrics.Data.Dto;
using Metrics.Data.Entity;
using Metrics.Data.Responses;
using MetricsManager.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsManager.Controllers
{
    //api/metrics/hdd/left/from/{fromTime}/to/{toTime}/
    //(размер оставшегося свободного дискового пространства в мегабайтах)

    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddMetricsController : Controller
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IHddMetricsRepository _repository;
        private readonly IMapper _mapper;

        public HddMetricsController(
            ILogger<HddMetricsController> logger,
            IHddMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("agent/left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetLeftFrom {fromTime}-{toTime}");

            IList<HddMetric> metrics = _repository.Get(fromTime, toTime);
            var response = GetResponse(metrics);

            return Ok(response);
        }

        private HddMetricsResponse GetResponse(IList<HddMetric> metrics)
        {
            var response = new HddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
                }
            }

            return response;
        }
    }
}
