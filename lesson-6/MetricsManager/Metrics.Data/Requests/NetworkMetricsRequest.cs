namespace Metrics.Data.Requests
{
    public class NetworkMetricsRequest : BaseMetricsRequest
    {
        public override string Url => $"{ClientBaseAddress}/api/metrics/network/from/{ToUrlDateTime(FromTime)}/to/{ToUrlDateTime(ToTime)}";

    }
}
