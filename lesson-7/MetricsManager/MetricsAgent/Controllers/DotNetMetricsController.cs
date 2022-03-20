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
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IDotNetMetricsRepository _repository;
        private readonly IMapper _mapper;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IDotNetMetricsRepository repository,
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

            IList<DotNetMetric> metrics = _repository.GetAll();
            var response = GetResponse(metrics);

            return Ok(response);
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetErrorsCountFrom {fromTime}-{toTime}");
            
            IList<DotNetMetric> metrics = _repository.GetAll();
            var response = GetResponse(metrics);

            return Ok(response);
        }

        private DotNetMetricsResponse GetResponse(IList<DotNetMetric> metrics)
        {
            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
                }
            }

            return response;
        }
    }
}
