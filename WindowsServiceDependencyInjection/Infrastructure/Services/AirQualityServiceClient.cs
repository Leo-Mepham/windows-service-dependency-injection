using Flurl.Http;
using Infrastructure.EntityFramwork;
using Infrastructure.Logging;
using System;

namespace Infrastructure.Services
{
    public class AirQualityServiceClient : IAirQualityServiceClient
    {
        private readonly ILog log;

        public AirQualityServiceClient(ILog log)
        {
            this.log = log;
        }

        public Forecast Get()
        {
            try
            {
                return "https://api.tfl.gov.uk/AirQuality".GetJsonAsync<Forecast>().Result;
            }
            catch(Exception ex)
            {
                log.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }
    }
}
