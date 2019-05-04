using System;

namespace Infrastructure.EntityFramwork
{
    public class ForecastElement
    {
        public int Id { get; set; }
        public string ForecastType { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ForecastBand { get; set; }
        public string ForecastSummary { get; set; }
        public string NO2Band { get; set; }
        public string O3Band { get; set; }
        public string PM10Band { get; set; }
        public string PM25Band { get; set; }
        public string SO2Band { get; set; }
        public string ForecastText { get; set; }
    }
}
