using AdventureWorks.Data.Models;
using AdventureWorks.Web.Configurations;
using Autofac;
using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class AdventureWorksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var adventureWorks = Assembly.Load(new AssemblyName("AdventureWorks.Data"));

            builder.RegisterAssemblyTypes(adventureWorks)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder.Register(x => 
                new AdventureWorks2014Context(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.AdventureWorks2014));
        }
    }
}
