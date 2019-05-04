using Autofac;
using Infrastructure.Logging;
using Infrastructure.Repositories;
using Infrastructure.Services;
using System.ServiceProcess;

namespace WindowsService
{
    static class Program
    {
        static void Main()
        {
            // New DI Container
            ContainerBuilder containerBuilder = new ContainerBuilder();

            // Load types into the container

            // The Windows service itself
            containerBuilder.RegisterType<AirQualityService>().AsSelf().InstancePerLifetimeScope();

            // Repositories
            containerBuilder.RegisterType<ForecastRepository>().As<IForecastRepository>().InstancePerLifetimeScope();

            // Logging
            containerBuilder.RegisterType<Log>().As<ILog>().InstancePerLifetimeScope();

            // Service classes
            containerBuilder.RegisterType<AirQualityServiceClient>().As<IAirQualityServiceClient>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<AirQualityRecorder>().As<IAirQualityRecorder>().InstancePerLifetimeScope();

            // Finalise the container
            IContainer container = containerBuilder.Build();

            // Ask the service to be run from the Dependency Injection container.
            // By doing this all the other interfaces/implementations will be available
            // through constructor matching
            ServiceBase.Run(container.Resolve<AirQualityService>());
        }
    }
}
