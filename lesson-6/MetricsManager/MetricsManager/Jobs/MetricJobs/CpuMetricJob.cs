using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsManager.Jobs.MetricJobs
{
    public class CpuMetricJob : AMetricJobBase<CpuMetric, int>, IJob
    {
        private ICpuMetricsRepository _repository;

        public CpuMetricJob(ICpuMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
