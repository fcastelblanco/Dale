using Autofac;
using Fgcm.Dale.Repository.IoC;

namespace Fgcm.Dale.ApplicationService.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterApplicationServiceResources(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterRepository();

            containerBuilder.RegisterType<DaleApplicationService>().As<IDaleApplicationService>().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}