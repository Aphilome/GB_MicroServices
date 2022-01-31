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
        private string[] _adapterNames; 

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _repository = repository;
            var networkCounterCategory = new PerformanceCounterCategory("Network Interface");
            _adapterNames = networkCounterCategory.GetInstanceNames();
        }

        public Task Execute(IJobExecutionContext context)
        {
            float networkSpeed = 0;
            foreach(var adapterName in _adapterNames)
            {
                var networkCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", adapterName);
                networkSpeed += networkCounter.NextValue();
            }
            _repository.Create(new NetworkMetric
            {
                DateTime = DateTime.UtcNow,
                Value = Convert.ToInt32(networkSpeed)
            });

            return Task.CompletedTask;
        }
    }
}
