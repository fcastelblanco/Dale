using Autofac;
using Fgcm.Dale.Data.IoC;
using Fgcm.Dale.Infraestructure.Implementations;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Concrete;

namespace Fgcm.Dale.Repository.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterRepository(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SaleDetailRepository>().As<ISaleDetailRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SaleRepository>().As<ISaleRepository>().InstancePerLifetimeScope();

            containerBuilder.RegisterDataResources();
            containerBuilder.RegisterInfraestructure();

            return containerBuilder;
        }
    }
}