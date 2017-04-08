using AdventureWorks.Data.Models;
using AdventureWorks.Web.Configurations;
using Autofac;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class AdventureWorksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var references = Assembly.GetEntryAssembly().GetReferencedAssemblies();

            var adventureWorksName = references.Single(x => x.Name == "AdventureWorks.Data");
            var adventureWorks = Assembly.Load(adventureWorksName);

            builder.RegisterAssemblyTypes(new[] { adventureWorks })
                .AsImplementedInterfaces();

            builder.Register(x => 
                new AdventureWorks2014Context(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.AdventureWorks2014));
        }
    }
}
