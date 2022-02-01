using Metrics.Data.Requests;
using Metrics.Data.Responses;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        Task<RamMetricsResponse> GetRamMetrics(RamMetricsRequest request);

        Task<HddMetricsResponse> GetHddMetrics(HddMetricsRequest request);

        Task<NetworkMetricsResponse> GetNetworkMetrics(NetworkMetricsRequest request);

        Task<DotNetMetricsResponse> GetDotNetMetrics(DotNetMetricsRequest request);

        Task<CpuMetricsResponse> GetCpuMetrics(CpuMetricsRequest request);
    }
}
