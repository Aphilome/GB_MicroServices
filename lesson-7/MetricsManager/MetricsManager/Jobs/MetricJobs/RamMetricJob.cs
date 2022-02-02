﻿using AutoMapper;
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
    public class RamMetricJob : IJob
    {
        private readonly IRamMetricsRepository _repository;
        private readonly IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        private readonly ILogger<RamMetricJob> _logger;

        public RamMetricJob(
            IRamMetricsRepository repository,
            IMetricsAgentClient metricsAgentClient,
            IMapper mapper,
            ILogger<RamMetricJob> logger)
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
                var response = await _metricsAgentClient.GetRamMetrics(new RamMetricsRequest
                {
                    FromTime = _repository.GetLastMetricDate(),
                    ToTime = DateTime.UtcNow
                });

                if (response?.Metrics?.Count > 0)
                {
                    foreach (var metric in response.Metrics)
                    {
                        _repository.Create(_mapper.Map<RamMetric>(metric));
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
