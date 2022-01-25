using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsAgent.DAL.Interfaces;

namespace MetricsManagerTests
{
    public class AgentNetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;
        private Mock<ILogger<NetworkMetricsController>> _loggerMoq;
        private Mock<INetworkMetricsRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<NetworkMetricsController>>();
            _repository = new Mock<INetworkMetricsRepository>();
            _networkMetricsController = new NetworkMetricsController(_loggerMoq.Object, _repository.Object);
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
