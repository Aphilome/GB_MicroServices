
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class AgentCpuMetricsControllerUnitTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ILogger<CpuMetricsController>> _loggerMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<CpuMetricsController>>();
            _cpuMetricsController = new CpuMetricsController(_loggerMoq.Object);
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
