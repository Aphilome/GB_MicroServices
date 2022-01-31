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
    public class AgentHddMetricsControllerUnitTest
    {
        private HddMetricsController _hddMetricsController;
        private Mock<ILogger<HddMetricsController>> _loggerMoq;
        private Mock<IHddMetricsRepository> _repository;
        private Mock<IMapper> _mapperMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<HddMetricsController>>();
            _repository = new Mock<IHddMetricsRepository>();
            _mapperMoq = new Mock<IMapper>();
            _hddMetricsController = new HddMetricsController(_loggerMoq.Object, _repository.Object, _mapperMoq.Object);
        }

        [Test]
        public void GetLeftFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _hddMetricsController.GetLeftFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public void GetAll_ReturnOk()
        {
            // Arrange

            // Act
            var result = _hddMetricsController.GetAll();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}
