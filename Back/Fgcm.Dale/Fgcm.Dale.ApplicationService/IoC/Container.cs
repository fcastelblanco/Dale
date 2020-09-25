using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Fgcm.Dale.Data.IoC;

namespace Fgcm.Dale.ApplicationService.IoC
{
    public static class Container
    {
        public static ContainerBuilder RegisterApplicationServiceResources(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterDataResources();

            containerBuilder.RegisterType<DaleApplicationService>().As<IDaleApplicationService>();

            return containerBuilder;
        }
    }
}
