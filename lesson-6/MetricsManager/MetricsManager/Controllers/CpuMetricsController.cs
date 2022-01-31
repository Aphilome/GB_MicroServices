using Metrics.Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{

    //api/metrics/cpu/from/{fromTime}/to/{toTime}/
    //https://localhost:5001/api/metrics/cpu/from/21.12.2020/to/30.12.2020/

    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : Controller
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetMetricsFrom([FromRoute]DateTime fromTime, [FromRoute]DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom with {fromTime}-{toTime}");

            var url = $"https://localhost:5001/api/metrics/cpu/from/{fromTime:yyyy-MM-ddThh:mm:ss}/to/{toTime:yyyy-MM-ddThh:mm:ss}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "*/*");
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var metricsResponse = await JsonSerializer.DeserializeAsync<CpuMetricsResponse>(responseStream);
                _logger.LogInformation($"recived: {metricsResponse.Metrics?.Count}");

            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                return Problem();
            }
            return Ok();
        }
    }
}
