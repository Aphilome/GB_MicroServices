using Metrics.Data.Dto;
using System.Collections.Generic;

namespace Metrics.Data.Responses
{
    public class RamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
}
