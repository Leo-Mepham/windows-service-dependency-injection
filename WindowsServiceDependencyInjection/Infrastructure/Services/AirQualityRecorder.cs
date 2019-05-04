using Infrastructure.Logging;
using Infrastructure.Repositories;
using System;

namespace Infrastructure.Services
{
    public class AirQualityRecorder : IAirQualityRecorder
    {
        private readonly ILog log;
        private readonly IAirQualityServiceClient airQualityServiceClient;
        private readonly IForecastRepository forecastRepository;

        public AirQualityRecorder(
            ILog log,
            IAirQualityServiceClient airQualityServiceClient,
            IForecastRepository forecastRepository)
        {
            this.log = log;
            this.airQualityServiceClient = airQualityServiceClient;
            this.forecastRepository = forecastRepository;
        }

        public void Record()
        {
            try
            {
                var forecast = airQualityServiceClient.Get();
                forecastRepository.Add(forecast);
            }
            catch(Exception ex)
            {
                log.Log(LogLevel.Error, ex.Message);
            }
        }
    }
}
