using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController _ramMetricsController;

        [SetUp]
        public void SetUp()
        {
            _ramMetricsController = new RamMetricsController();
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
    }
}
