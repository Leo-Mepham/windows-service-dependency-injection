using Infrastructure.EntityFramwork;

namespace Infrastructure.Services
{
    public interface IAirQualityServiceClient
    {
        Forecast Get();
    }
}
