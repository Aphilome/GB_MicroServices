﻿using Metrics.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Metrics.Data.Responses
{
    public class NetworkMetricsResponse
    {
        [JsonPropertyName("metrics")]
        public List<NetworkMetricDto> Metrics { get; set; }
    }
}
