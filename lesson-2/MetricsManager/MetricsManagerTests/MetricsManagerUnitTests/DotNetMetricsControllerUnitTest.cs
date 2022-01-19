using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace MetricsManagerTests.MetricsManagerUnitTests
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _dotNetMetricsController;

        [SetUp]
        public void Setup()
        {
            _dotNetMetricsController = new DotNetMetricsController();
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
