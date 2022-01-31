using Metrics.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Data.Responses
{
    public class HddMetricsResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }
}
