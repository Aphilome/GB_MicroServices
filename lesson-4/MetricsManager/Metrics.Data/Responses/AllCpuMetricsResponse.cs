using Metrics.Data.Dto;
using System.Collections.Generic;

namespace Metrics.Data.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
