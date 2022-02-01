using AutoMapper;
using Metrics.Data.Entity;
using Metrics.Data.Requests;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class DotNetMetricJob : IJob
    {
        private readonly IDotNetMetricsRepository _repository;
        private readonly IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        private readonly ILogger<DotNetMetricJob> _logger;

        public DotNetMetricJob(
            IDotNetMetricsRepository repository,
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper,
            ILogger<DotNetMetricJob> logger)
        {
            _repository = repository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var response = await _metricsAgentClient.GetDotNetMetrics(new DotNetMetricsRequest
                {
                    FromTime = _repository.GetLastMetricDate(),
                    ToTime = DateTime.UtcNow
                });

                if (response?.Metrics?.Count > 0)
                {
                    foreach (var metric in response.Metrics)
                    {
                        _repository.Create(_mapper.Map<DotNetMetric>(metric));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
