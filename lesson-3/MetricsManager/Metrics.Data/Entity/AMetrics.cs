using System;

namespace Metrics.Data.Entity
{
    public abstract class AMetrics<T>
    {
        public int Id { get; set; }

        public T Value { get; set; }

        public DateTime DateTime { get; set; }
    }
}
