using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _hddMetricsController;

        [SetUp]
        public void SetUp()
        {
            _hddMetricsController = new HddMetricsController();
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
