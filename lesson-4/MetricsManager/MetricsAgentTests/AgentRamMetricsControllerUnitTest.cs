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
    public class AgentRamMetricsControllerUnitTest
    {
        private RamMetricsController _ramMetricsController;
        private Mock<ILogger<RamMetricsController>> _loggerMoq;
        private Mock<IRamMetricsRepository> _repository;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<RamMetricsController>>();
            _repository = new Mock<IRamMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _ramMetricsController = new RamMetricsController(_loggerMoq.Object, _repository.Object, _mapperMoq.Object);
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

        [Test]
        public void GetAll_ReturnOk()
        {
            // Arrange

            // Act
            var result = _ramMetricsController.GetAll();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
