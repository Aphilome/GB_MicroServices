using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class NetworkMetricJob : AMetricJobBase<NetworkMetric, int>, IJob
    {
        private INetworkMetricsRepository _repository;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
