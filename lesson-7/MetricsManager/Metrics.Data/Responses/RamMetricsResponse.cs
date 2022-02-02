using Metrics.Data.Dto;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Metrics.Data.Responses
{
    public class RamMetricsResponse
    {
        [JsonPropertyName("metrics")]
        public List<RamMetricDto> Metrics { get; set; }
    }
}
