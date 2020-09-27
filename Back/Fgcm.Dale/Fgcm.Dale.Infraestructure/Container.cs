using Autofac;
using Fgcm.Dale.Data.IoC;

namespace Fgcm.Dale.Infraestructure
{
    public static class Container
    {
        public static ContainerBuilder RegisterInfraestructure(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterDataResources();

            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            return containerBuilder;
        }
    }
}