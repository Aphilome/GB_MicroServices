using Metrics.Data.Dto;
using System.Collections.Generic;

namespace Metrics.Data.Responses
{
    public class CpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
