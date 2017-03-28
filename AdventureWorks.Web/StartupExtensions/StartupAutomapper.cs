using AdventureWorks.Data.Models;
using AdventureWorks.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.StartupExtensions
{
    public static class StartupAutomapper
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapperConfiguration();
            
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>()));            
        }

        private static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonVM>();
                cfg.CreateMap<Employee, EmployeeVM>();
            });

            //config.AssertConfigurationIsValid();

            services.AddSingleton<IConfigurationProvider>(config);
        }
    }
}
