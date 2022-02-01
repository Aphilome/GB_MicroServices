using Metrics.Data.Entity;
using System;
using System.Diagnostics;

namespace MetricsManager.Jobs.MetricJobs
{
    public abstract class AMetricJobBase<T, V>
        where T : AMetric<V>, new()
    {

    }
}
