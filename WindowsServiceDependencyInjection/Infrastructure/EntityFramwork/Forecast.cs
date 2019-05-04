using System.Collections.Generic;

namespace Infrastructure.EntityFramwork
{
    public class Forecast
    {
        public int Id { get; set; }
        public string UpdatePeriod { get; set; }
        public string UpdateFrequency { get; set; }
        public string ForecastURL { get; set; }
        public string DisclaimerText { get; set; }
        public List<ForecastElement> CurrentForecast { get; set; }
    }
}
