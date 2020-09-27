using Autofac;
using Fgcm.Dale.Data.IoC;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Concrete;

namespace Fgcm.Dale.Repository.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterRepository(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<SaleDetailRepository>().As<ISaleDetailRepository>();
            containerBuilder.RegisterType<SaleRepository>().As<ISaleRepository>();

            containerBuilder.RegisterDataResources();
            containerBuilder.RegisterInfraestructure();

            return containerBuilder;
        }
    }
}