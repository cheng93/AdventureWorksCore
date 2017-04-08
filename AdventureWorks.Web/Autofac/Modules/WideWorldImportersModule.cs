using AdventureWorks.Web.Configurations;
using Autofac;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using WideWorldImporters.Data.Models;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class WideWorldImportersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var references = Assembly.GetEntryAssembly().GetReferencedAssemblies();

            var adventureWorksName = references.Single(x => x.Name == "WideWorldImporters.Data");
            var adventureWorks = Assembly.Load(adventureWorksName);

            builder.RegisterAssemblyTypes(new[] { adventureWorks })
                .AsImplementedInterfaces();

            builder.Register(x =>
                new WideWorldImportersContext(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.WideWorldImporters));

        }
    }
}
