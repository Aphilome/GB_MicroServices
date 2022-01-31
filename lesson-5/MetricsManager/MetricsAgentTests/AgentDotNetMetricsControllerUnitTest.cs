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
    public class AgentDotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _dotNetMetricsController;
        private Mock<ILogger<DotNetMetricsController>> _loggerMoq;
        private Mock<IDotNetMetricsRepository> _repository;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<DotNetMetricsController>>();
            _mapperMoq = new Mock<IMapper>();
            _repository = new Mock<IDotNetMetricsRepository>();
            _dotNetMetricsController = new DotNetMetricsController(_loggerMoq.Object, _repository.Object, _mapperMoq.Object);
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

        [Test]
        public void GetAll_ReturnOk()
        {
            // Arrange

            // Act
            var result = _dotNetMetricsController.GetAll();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
