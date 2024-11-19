using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRemember.Application.Interfaces;
using MyRemember.Persistence;

namespace MyRemember.Persistence
{
    public static class MyRememberPersistenceModule
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRememberTenantDb")));
            services.AddScoped<IAuthDbContext, AuthDbContext>();

            return services;

        }
    }
}
