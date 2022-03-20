using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using AutoMapper;

namespace MetricsManagerTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;
        private Mock<ILogger<NetworkMetricsController>> _loggerMoq;
        private Mock<INetworkMetricsRepository> _repositoryMoq;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<NetworkMetricsController>>();
            _repositoryMoq = new Mock<INetworkMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _networkMetricsController = new NetworkMetricsController(_loggerMoq.Object, _repositoryMoq.Object, _mapperMoq.Object);
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
    }
}
