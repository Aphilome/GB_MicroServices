using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;
using MetricsAgent.DAL.Interfaces;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class AgentHddMetricsControllerUnitTest
    {
        private HddMetricsController _hddMetricsController;
        private Mock<ILogger<HddMetricsController>> _loggerMoq;
        private Mock<IHddMetricsRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<HddMetricsController>>();
            _repository = new Mock<IHddMetricsRepository>();
            _hddMetricsController = new HddMetricsController(_loggerMoq.Object, _repository.Object);
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
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
