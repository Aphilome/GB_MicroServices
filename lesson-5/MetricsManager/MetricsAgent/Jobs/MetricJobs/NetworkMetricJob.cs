using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class NetworkMetricJob : AMetricJobBase<NetworkMetric, int>, IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metric = GetMetricBase(_networkCounter);
            _repository.Create(metric);

            return Task.CompletedTask;
        }
    }
}
