using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.EntityFramwork
{
    public class AirQualityContext : DbContext
    {
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<ForecastElement> ForecastElements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }
    }
}
