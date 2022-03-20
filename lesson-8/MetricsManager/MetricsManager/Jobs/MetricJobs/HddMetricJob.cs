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
    public class HddMetricJob : IJob
    {
        private readonly IHddMetricsRepository _repository;
        private readonly IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        private readonly ILogger<HddMetricJob> _logger;

        public HddMetricJob(
            IHddMetricsRepository repository,
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper,
            ILogger<HddMetricJob> logger)
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
                var response = await _metricsAgentClient.GetHddMetrics(new HddMetricsRequest
                {
                    FromTime = _repository.GetLastMetricDate(),
                    ToTime = DateTime.UtcNow
                });

                if (response?.Metrics?.Count > 0)
                {
                    foreach (var metric in response.Metrics)
                    {
                        _repository.Create(_mapper.Map<HddMetric>(metric));
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
