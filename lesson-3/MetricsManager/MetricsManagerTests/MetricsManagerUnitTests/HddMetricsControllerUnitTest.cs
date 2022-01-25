using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using Moq;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _hddMetricsController;
        private Mock<ILogger<HddMetricsController>> _loggerMoq;

        [SetUp]
        public void SetUp()
        {
            _loggerMoq = new Mock<ILogger<HddMetricsController>>();
            _hddMetricsController = new HddMetricsController(_loggerMoq.Object);
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
