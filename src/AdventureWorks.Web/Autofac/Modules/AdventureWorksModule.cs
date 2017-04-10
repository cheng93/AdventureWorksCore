using AdventureWorks.Data.Models;
using AdventureWorks.Web.Configurations;
using Autofac;
using Microsoft.Extensions.Options;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class AdventureWorksModule : DataModule
    {
        public AdventureWorksModule() 
            : base("AdventureWorks.Data")
        {
        }

        protected override void RegisterDataAccess(ContainerBuilder builder)
        {
            builder.Register(x =>
                new AdventureWorks2014Context(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.AdventureWorks2014));
        }
    }
}
