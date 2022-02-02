using System;
using System.Text.Json.Serialization;

namespace Metrics.Data.Dto
{
    public abstract class AMetricDto<T>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public T Value { get; set; }

        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
    }
}
