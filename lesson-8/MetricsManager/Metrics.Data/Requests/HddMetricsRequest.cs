namespace Metrics.Data.Requests
{
    public class HddMetricsRequest : BaseMetricsRequest
    {
        public override string Url => $"{ClientBaseAddress}/api/metrics/hdd/left/from/{ToUrlDateTime(FromTime)}/to/{ToUrlDateTime(ToTime)}";
    }
}
