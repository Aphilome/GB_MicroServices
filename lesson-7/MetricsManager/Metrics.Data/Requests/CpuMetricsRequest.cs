namespace Metrics.Data.Requests
{
    public class CpuMetricsRequest : BaseMetricsRequest
    {
        public override string Url => $"{ClientBaseAddress}/api/metrics/cpu/from/{ToUrlDateTime(FromTime)}/to/{ToUrlDateTime(ToTime)}";
    }
}
