using AdventureWorks.Data.Models;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Web.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AdventureWorks.Web.StartupExtensions
{
    public static class StartupInjection
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<AdventureWorks2014Context, AdventureWorks2014Context>(sp =>
                new AdventureWorks2014Context(sp.GetRequiredService<IOptions<ConnectionStringsOptions>>().Value.AdventureWorks2014)
            );

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeDepartmentHistoryRepository, EmployeeRepository>();
        }
    }
}
