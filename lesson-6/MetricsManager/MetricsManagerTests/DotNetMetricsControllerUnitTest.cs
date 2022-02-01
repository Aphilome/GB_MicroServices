using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsManager.Client;

namespace MetricsManagerTests
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _dotNetMetricsController;
        private Mock<ILogger<DotNetMetricsController>> _loggerMoq;
        private Mock<IMetricsAgentClient> _metricsClientMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<DotNetMetricsController>>();
            _metricsClientMoq = new Mock<IMetricsAgentClient>();
            _dotNetMetricsController = new DotNetMetricsController(_loggerMoq.Object, _metricsClientMoq.Object);
        }

        [Test]
        public void GetErrorsCountFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _dotNetMetricsController.GetErrorsCountFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
