using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class DotNetMetricJob : AMetricJobBase<DotNetMetric, int>, IJob
    {
        private IDotNetMetricsRepository _repository;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
