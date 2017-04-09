using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterType<Mediator>()
              .As<IMediator>()
              .SingleInstance();

            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();
            
            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            // .NET Core 2.0 will have AppDomain method for scanning assemblies.
            var assemblyNames = new[] { "AdventureWorks.Data", "WideWorldImporters.Data " };
            var assemblies = assemblyNames
                .Select(x => new AssemblyName(x))
                .Select(x => Assembly.Load(x));
        }
    }
}
