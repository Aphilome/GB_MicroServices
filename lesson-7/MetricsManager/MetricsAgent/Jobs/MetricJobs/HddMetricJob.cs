using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class HddMetricJob : AMetricJobBase<HddMetric, int>, IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
            _hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "0 C: D:");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metric = GetMetricBase(_hddCounter);
            _repository.Create(metric);

            return Task.CompletedTask;
        }
    }
}
