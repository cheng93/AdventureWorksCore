using AdventureWorks.Web.Autofac.Modules;
using Autofac;

namespace AdventureWorks.Web.Autofac
{
    public static class AutofacExtensions
    {
        public static void AddModules(this ContainerBuilder builder)
        {
            builder.RegisterModule<AdventureWorksModule>();
            builder.RegisterModule<WideWorldImportersModule>();
        }
    }
}
