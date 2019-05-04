using System;
using Infrastructure.EntityFramwork;
using Infrastructure.Logging;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Infrastructure.Tests
{
    [TestClass]
    public class AirQualityRecorderTests
    {
        [TestMethod]
        public void AirQualityRecorderGetsAndAdds()
        {
            // Arrange
            var log = Substitute.For<ILog>();
            var airQualityServiceClient = Substitute.For<IAirQualityServiceClient>();
            var forecastRepository = Substitute.For<IForecastRepository>();
            var forecast = new Forecast();

            airQualityServiceClient.Get().Returns(forecast);

            // Act
            var airQualityRecorder = new AirQualityRecorder(log, airQualityServiceClient, forecastRepository);
            airQualityRecorder.Record();

            // Assert
            forecastRepository.Received(1).Add(forecast);
        }

        [TestMethod]
        public void AirQualityRecorderLogsErrors()
        {
            // Arrange
            var log = Substitute.For<ILog>();
            var airQualityServiceClient = Substitute.For<IAirQualityServiceClient>();
            var forecastRepository = Substitute.For<IForecastRepository>();
            var forecast = new Forecast();

            airQualityServiceClient.Get().Returns(ex => throw new Exception("Error"));

            // Act
            var airQualityRecorder = new AirQualityRecorder(log, airQualityServiceClient, forecastRepository);
            airQualityRecorder.Record();

            // Assert
            forecastRepository.Received(0).Add(forecast);
            log.Received(1).Log(LogLevel.Error, "Error");
        }
    }
}
