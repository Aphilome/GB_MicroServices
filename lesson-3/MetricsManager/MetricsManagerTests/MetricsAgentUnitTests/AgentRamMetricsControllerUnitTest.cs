using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsAgent.DAL.Interfaces;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class AgentRamMetricsControllerUnitTest
    {
        private RamMetricsController _ramMetricsController;
        private Mock<ILogger<RamMetricsController>> _loggerMoq;
        private Mock<IRamMetricsRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<RamMetricsController>>();
            _repository = new Mock<IRamMetricsRepository>();
            _ramMetricsController = new RamMetricsController(_loggerMoq.Object, _repository.Object);
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
