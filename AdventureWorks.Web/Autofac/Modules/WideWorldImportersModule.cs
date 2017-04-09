    using AdventureWorks.Web.Configurations;
using Autofac;
using Microsoft.Extensions.Options;
using WideWorldImporters.Data.Models;

namespace AdventureWorks.Web.Autofac.Modules
{
    public class WideWorldImportersModule : DataModule
    {
        public WideWorldImportersModule() 
            : base("WideWorldImporters.Data")
        {
        }

        protected override void RegisterDataAccess(ContainerBuilder builder)
        {
            builder.Register(x =>
                new WideWorldImportersContext(x.Resolve<IOptions<ConnectionStringsOptions>>().Value.WideWorldImporters));
        }
    }
}
