using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class CpuMetricJob : AMetricJobBase<CpuMetric, int>, IJob
    {
        private ICpuMetricsRepository _repository;

        // счетчик для метрики CPU
        private PerformanceCounter _cpuCounter;

        public CpuMetricJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            var metric = GetMetricBase(_cpuCounter);
            _repository.Create(metric);

            return Task.CompletedTask;
        }
    }
}
