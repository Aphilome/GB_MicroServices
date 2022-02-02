using Metrics.Data.Entity;
using System;
using System.Diagnostics;

namespace MetricsAgent.Jobs.MetricJobs
{
    public abstract class AMetricJobBase<T, V>
        where T : AMetric<V>, new()
    {
        public T GetMetricBase(PerformanceCounter performanceCounter)
        {
            // получаем значение
            var value = Convert.ToInt32(performanceCounter.NextValue());

            // узнаем когда мы сняли значение метрики.
            var dateTime = DateTime.UtcNow;

            // теперь можно записать что-то при помощи репозитория
            return new T
            {
                DateTime = dateTime,
                Value = (V)(object)value
            };
        }
    }
}
