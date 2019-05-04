using Infrastructure.EntityFramwork;

namespace Infrastructure.Repositories
{
    public interface IForecastRepository
    {
        void Add(Forecast forecast);
    }
}
