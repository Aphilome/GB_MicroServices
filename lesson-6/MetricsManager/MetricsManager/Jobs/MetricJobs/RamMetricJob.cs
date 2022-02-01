using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class RamMetricJob : AMetricJobBase<RamMetric, int>, IJob
    {
        private IRamMetricsRepository _repository;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
