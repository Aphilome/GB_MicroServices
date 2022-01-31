using System;

namespace Metrics.Data.Dto
{
    public abstract class AMetricDto<T>
    {
        public int Id { get; set; }

        public T Value { get; set; }

        public DateTime DateTime { get; set; }
    }
}
