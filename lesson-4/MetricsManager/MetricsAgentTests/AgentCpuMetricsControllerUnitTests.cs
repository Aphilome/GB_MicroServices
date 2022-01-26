
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace MetricsManagerTests
{
    public class AgentCpuMetricsControllerUnitTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ILogger<CpuMetricsController>> _loggerMoq;
        private Mock<ICpuMetricsRepository> _repository;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<CpuMetricsController>>();
            _mapperMoq = new Mock<IMapper>();
            _repository = new Mock<ICpuMetricsRepository>();
            _cpuMetricsController = new CpuMetricsController(_loggerMoq.Object, _repository.Object, _mapperMoq.Object);
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

        [Test]
        public void GetAll_ReturnOk()
        {
            // Arrange

            // Act
            var result = _cpuMetricsController.GetAll();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
