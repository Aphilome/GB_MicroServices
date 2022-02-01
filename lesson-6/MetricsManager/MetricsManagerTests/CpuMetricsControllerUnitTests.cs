using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsManager.Client;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ILogger<CpuMetricsController>> _loggerMoq;
        private Mock<IMetricsAgentClient> _metricsClientMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<CpuMetricsController>>();
            _metricsClientMoq = new Mock<IMetricsAgentClient>();
            _cpuMetricsController = new CpuMetricsController(_loggerMoq.Object, _metricsClientMoq.Object);
        }

        [Test]
        public void GetMetricsFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _cpuMetricsController.GetMetricsFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
