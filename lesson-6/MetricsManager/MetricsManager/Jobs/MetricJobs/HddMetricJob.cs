using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class HddMetricJob : AMetricJobBase<HddMetric, int>, IJob
    {
        private IHddMetricsRepository _repository;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
