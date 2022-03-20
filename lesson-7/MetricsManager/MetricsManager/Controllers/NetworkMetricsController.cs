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
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly INetworkMetricsRepository _repository;
        private readonly IMapper _mapper;

        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger,
            INetworkMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom {fromTime}-{toTime}");

            IList<NetworkMetric> metrics = _repository.Get(fromTime, toTime);
            var response = GetResponse(metrics);

            return Ok(response);
        }

        private NetworkMetricsResponse GetResponse(IList<NetworkMetric> metrics)
        {
            var response = new NetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
                }
            }

            return response;
        }
    }
}
