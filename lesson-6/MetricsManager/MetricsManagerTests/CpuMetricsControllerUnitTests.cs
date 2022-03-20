using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using AutoMapper;
using MetricsManager.DAL.Interfaces;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ILogger<CpuMetricsController>> _loggerMoq;
        private Mock<ICpuMetricsRepository> _repositoryMoq;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<CpuMetricsController>>();
            _repositoryMoq = new Mock<ICpuMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _cpuMetricsController = new CpuMetricsController(_loggerMoq.Object, _repositoryMoq.Object, _mapperMoq.Object);
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
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
