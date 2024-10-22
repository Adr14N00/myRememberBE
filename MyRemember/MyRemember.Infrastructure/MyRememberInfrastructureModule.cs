using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRemember.Application.Interfaces;
using MyRemember.Infrastructure.Data.Auth;

namespace MyRemember.Infrastructure
{
    public static class MyRememberInfrastructureModule
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRememberTenantDb")));
            services.AddScoped<IAuthDbContext, AuthDbContext>();

            return services;

        }
    }
}
