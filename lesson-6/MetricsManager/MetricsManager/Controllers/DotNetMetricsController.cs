using Metrics.Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Controllers
{
    //api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotNetMetricsController : Controller
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCountFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetErrorsCountFrom {fromTime}-{toTime}");

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5001/api/metrics/dotnet/all");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<DotNetMetricsResponse>(responseStream).Result;
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
