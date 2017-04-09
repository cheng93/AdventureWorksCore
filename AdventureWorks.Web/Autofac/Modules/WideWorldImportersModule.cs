using AdventureWorks.Web.Configurations;
using Autofac;
using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;
using WideWorldImporters.Data.Models;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class WideWorldImportersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var wideWorldImporters = Assembly.Load(new AssemblyName("WideWorldImporters.Data"));

            builder.RegisterAssemblyTypes(wideWorldImporters)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder.Register(x =>
                new WideWorldImportersContext(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.WideWorldImporters));

        }
    }
}
