using MetricsManager.Client;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController _ramMetricsController;
        private Mock<ILogger<RamMetricsController>> _loggerMoq;
        private Mock<IMetricsAgentClient> _metricsClientMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<RamMetricsController>>();
            _metricsClientMoq = new Mock<IMetricsAgentClient>();
            _ramMetricsController = new RamMetricsController(_loggerMoq.Object, _metricsClientMoq.Object);
        }

        [Test]
        public void GetMetricsAvailableFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _ramMetricsController.GetMetricsAvailableFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
