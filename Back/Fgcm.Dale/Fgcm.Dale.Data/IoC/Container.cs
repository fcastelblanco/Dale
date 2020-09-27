using Autofac;
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

            containerBuilder.Register(x => new ConnectionStringProvider
            {
                ConnectionString = configuration.GetConnectionString("Fgcm.Dale")
            }).As<IConnectionStringProvider>();

            containerBuilder.RegisterType<DaleContext>().As<DbContext>();

            return containerBuilder;
        }
    }
}