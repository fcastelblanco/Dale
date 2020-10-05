using Autofac;
using Fgcm.Dale.Infraestructure.Definitions;

namespace Fgcm.Dale.Infraestructure.Implementations
{
    public static class Container
    {
        public static ContainerBuilder RegisterInfraestructure(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}