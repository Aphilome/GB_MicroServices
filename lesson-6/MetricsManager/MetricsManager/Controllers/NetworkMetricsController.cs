﻿using Metrics.Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;

namespace MetricsManager.Controllers
{
    //api/metrics/network/from/{fromTime}/to/{toTime}/
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("agent/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFrom(DateTime fromTime, DateTime toTime)
        {
            _logger.LogInformation($"call GetMetricsFrom {fromTime}-{toTime}");

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5001/api/metrics/network/all");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<NetworkMetricsResponse>(responseStream).Result;
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