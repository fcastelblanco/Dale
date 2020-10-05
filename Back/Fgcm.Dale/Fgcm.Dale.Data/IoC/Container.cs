using Autofac;
using Fgcm.Dale.Infraestructure.Definitions;
using Fgcm.Dale.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fgcm.Dale.Data.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterDataResources(this ContainerBuilder containerBuilder)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            containerBuilder.Register(x => new ConnectionStringProvider(configuration.GetConnectionString("Fgcm.Dale"))
            ).As<IConnectionStringProvider>();

            containerBuilder.RegisterType<DaleContext>().As<DbContext>().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}