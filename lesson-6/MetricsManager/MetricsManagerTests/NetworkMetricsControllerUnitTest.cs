using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsManager.Client;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;
        private Mock<ILogger<NetworkMetricsController>> _loggerMoq;
        private Mock<IMetricsAgentClient> _metricsClientMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<NetworkMetricsController>>();
            _metricsClientMoq = new Mock<IMetricsAgentClient>();
            _networkMetricsController = new NetworkMetricsController(_loggerMoq.Object, _metricsClientMoq.Object);
        }

        [Test]
        public void GetMetricsFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _networkMetricsController.GetMetricsFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
