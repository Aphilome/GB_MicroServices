namespace Metrics.Data.Requests
{
    public class DotNetMetricsRequest : BaseMetricsRequest
    {
        public override string Url => $"{ClientBaseAddress}/api/metrics/dotnet/from/{ToUrlDateTime(FromTime)}/to/{ToUrlDateTime(ToTime)}";
    }
}
