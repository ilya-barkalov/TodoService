using Application.Common.Interfaces;

using Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("MemoryDatabase")
                );
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"), 
                        o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    )
                );
            }

            services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
