using AdventureWorks.Aop.Hooks;
using AdventureWorks.Aop.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public abstract class DataModule : Module
    {
        private readonly AssemblyName _assemblyName;

        protected DataModule(string assemblyName)
        {
            _assemblyName = new AssemblyName(assemblyName);
        }

        protected abstract void RegisterDataAccess(ContainerBuilder builder);

        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(_assemblyName);

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces()
                .EnableClassInterceptors(new ProxyGenerationOptions(new RequestHandlerGenerationHook()))
                .InterceptedBy(typeof(LoggingInterceptor));

            RegisterDataAccess(builder);
        }
    }
}
