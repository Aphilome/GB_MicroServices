
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
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
        private Mock<ICpuMetricsRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<CpuMetricsController>>();
            _repository = new Mock<ICpuMetricsRepository>();
            _cpuMetricsController = new CpuMetricsController(_loggerMoq.Object, _repository.Object);
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
