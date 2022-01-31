using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class DotNetMetricJob : AMetricJobBase<DotNetMetric, int>, IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _dotNetCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
            _dotNetCounter = new PerformanceCounter(".NET CLR Memory", "% Time in GC");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metric = GetMetricBase(_dotNetCounter);
            _repository.Create(metric);

            return Task.CompletedTask;
        }
    }
}
