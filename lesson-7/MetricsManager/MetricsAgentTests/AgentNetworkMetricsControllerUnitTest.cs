using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsAgent.DAL.Interfaces;
using AutoMapper;

namespace MetricsManagerTests
{
    public class AgentNetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;
        private Mock<ILogger<NetworkMetricsController>> _loggerMoq;
        private Mock<INetworkMetricsRepository> _repository;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<NetworkMetricsController>>();
            _repository = new Mock<INetworkMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _networkMetricsController = new NetworkMetricsController(_loggerMoq.Object, _repository.Object, _mapperMoq.Object);
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
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public void GetAll_ReturnOk()
        {
            // Arrange

            // Act
            var result = _networkMetricsController.GetAll();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
