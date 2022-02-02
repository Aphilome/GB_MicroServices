using Metrics.Data.Dto;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Metrics.Data.Responses
{
    public class CpuMetricsResponse
    {
        [JsonPropertyName("metrics")]
        public List<CpuMetricDto> Metrics { get; set; }
    }
}
