namespace Metrics.Data.Requests
{
    public class RamMetricsRequest : BaseMetricsRequest
    {
        public override string Url => $"{ClientBaseAddress}/api/metrics/ram/available/from/{ToUrlDateTime(FromTime)}/to/{ToUrlDateTime(ToTime)}";
    }
}
