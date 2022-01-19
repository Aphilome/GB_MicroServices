using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _networkMetricsController;

        [SetUp]
        public void SetUp()
        {
            _networkMetricsController = new NetworkMetricsController();
        }

        [Test]
        public void GetMetricsFrom_ReturnOk()
        {
            // Arrange
            DateTime fromTime = DateTime.Now;
            DateTime toTime = DateTime.Now.AddDays(1);

            // Act
            var result = _networkMetricsController.GetMetricsFrom(fromTime, toTime);

            // Assert
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
