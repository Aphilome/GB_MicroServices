using Metrics.Data.Dto;
using System.Collections.Generic;

namespace Metrics.Data.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }
    }
}
