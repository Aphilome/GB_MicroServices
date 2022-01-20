using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;
        private Mock<ILogger<NetworkMetricsController>> _loggerMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<NetworkMetricsController>>();
            _networkMetricsController = new NetworkMetricsController(_loggerMoq.Object);
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
