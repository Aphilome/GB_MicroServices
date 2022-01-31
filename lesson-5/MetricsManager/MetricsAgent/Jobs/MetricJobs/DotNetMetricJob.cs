using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class DotNetMetricJob : IJob
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
            // получаем значение занятости CPU
            var cpuUsageInPercents = Convert.ToInt32(_dotNetCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var dateTime = DateTime.UtcNow;

            // теперь можно записать что-то при помощи репозитория
            _repository.Create(new Metrics.Data.Entity.DotNetMetric
            {
                DateTime = dateTime,
                Value = cpuUsageInPercents
            });

            return Task.CompletedTask;
        }
    }
}
