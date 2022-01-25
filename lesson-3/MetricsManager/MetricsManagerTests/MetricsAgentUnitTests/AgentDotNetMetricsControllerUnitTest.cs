using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsAgent.DAL.Interfaces;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class AgentDotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _dotNetMetricsController;
        private Mock<ILogger<DotNetMetricsController>> _loggerMoq;
        private Mock<IDotNetMetricsRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _loggerMoq = new Mock<ILogger<DotNetMetricsController>>();
            _repository = new Mock<IDotNetMetricsRepository>();
            _dotNetMetricsController = new DotNetMetricsController(_loggerMoq.Object, _repository.Object);
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
    }
}
