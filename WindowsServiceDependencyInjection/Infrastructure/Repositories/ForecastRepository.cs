using Infrastructure.EntityFramwork;
using Infrastructure.Logging;
using System;

namespace Infrastructure.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly ILog log;

        public ForecastRepository(ILog log)
        {
            this.log = log;
        }

        public void Add(Forecast forecast)
        {
            try
            {
                using (var context = new AirQualityContext())
                {
                    context.Database.EnsureCreated();
                    context.Forecasts.Add(forecast);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                log.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }
    }
}
