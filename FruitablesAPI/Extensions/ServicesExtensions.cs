using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace FruitablesAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSql(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FruitablesAPI")));

        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }


    }
}
