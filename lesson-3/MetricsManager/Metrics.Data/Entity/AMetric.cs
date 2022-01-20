using System;

namespace Metrics.Data.Entity
{
    public abstract class AMetric<T>
    {
        public int Id { get; set; }

        public T Value { get; set; }

        public DateTime DateTime { get; set; }
    }
}
