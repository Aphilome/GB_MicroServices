using System;

namespace Metrics.Data.Requests
{
    public abstract class BaseMetricsRequest
    {
        public string ClientBaseAddress => "https://localhost:5001";

        public virtual string Url => string.Empty;

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        protected string ToUrlDateTime(DateTime dt) => dt.ToString("yyyy-MM-ddThh:mm:ss");
    }
}
