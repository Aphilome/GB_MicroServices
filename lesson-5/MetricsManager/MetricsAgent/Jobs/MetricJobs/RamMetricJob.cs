using MetricsAgent.DAL.Interfaces;
using Quartz;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs.MetricJobs
{
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            // теперь можно записать что-то при помощи репозитория

            return Task.CompletedTask;
        }
    }
}
