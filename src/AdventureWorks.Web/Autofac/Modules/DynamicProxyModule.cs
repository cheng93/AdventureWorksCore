using AdventureWorks.Aop.Interceptors;
using Autofac;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class DynamicProxyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoggingInterceptor>();
        }
    }
}
