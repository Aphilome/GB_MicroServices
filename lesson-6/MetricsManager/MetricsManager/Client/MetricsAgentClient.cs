using Metrics.Data.Requests;
using Metrics.Data.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MetricsAgentClient> _logger;

        public MetricsAgentClient(HttpClient httpClient, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CpuMetricsResponse> GetCpuMetrics(CpuMetricsRequest request)
        {
            return await SendRequest<CpuMetricsResponse>(request.Url);
        }

        public async Task<DotNetMetricsResponse> GetDotNetMetrics(DotNetMetricsRequest request)
        {
            return await SendRequest<DotNetMetricsResponse>(request.Url);
        }

        public async Task<HddMetricsResponse> GetHddMetrics(HddMetricsRequest request)
        {
            return await SendRequest<HddMetricsResponse>(request.Url);
        }

        public async Task<NetworkMetricsResponse> GetNetworkMetrics(NetworkMetricsRequest request)
        {
            return await SendRequest<NetworkMetricsResponse>(request.Url);
        }

        public async Task<RamMetricsResponse> GetRamMetrics(RamMetricsRequest request)
        {
            return await SendRequest<RamMetricsResponse>(request.Url);
        }

        private async Task<T> SendRequest<T>(string url)
               where T : class
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var response = await _httpClient.SendAsync(httpRequest);
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(responseStream);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
