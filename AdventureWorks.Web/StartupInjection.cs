using AdventureWorks.Data.Models;
using AdventureWorks.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web
{
    public static class StartupInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAdventureWorks2014Context, AdventureWorks2014Context>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
