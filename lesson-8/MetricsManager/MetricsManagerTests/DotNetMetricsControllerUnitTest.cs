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
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _dotNetMetricsController;
        private Mock<ILogger<DotNetMetricsController>> _loggerMoq;
        private Mock<IDotNetMetricsRepository> _repositoryMoq;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<DotNetMetricsController>>();
            _repositoryMoq = new Mock<IDotNetMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _dotNetMetricsController = new DotNetMetricsController(_loggerMoq.Object, _repositoryMoq.Object, _mapperMoq.Object);
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
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
