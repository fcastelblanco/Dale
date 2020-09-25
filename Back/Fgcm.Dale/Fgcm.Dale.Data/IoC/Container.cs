using Autofac;
using Fgcm.Dale.Data.Repository;
using Fgcm.Dale.Repository;

namespace Fgcm.Dale.Data.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterDataResources(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DaleContext>();
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<SaleDetailRepository>().As<ISaleDetailRepository>();
            containerBuilder.RegisterType<SaleRepository>().As<ISaleRepository>();

            return containerBuilder;
        }
    }
}
