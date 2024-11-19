using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRemember.Application.Interfaces;

namespace MyRemember.Infrastructure
{
    public static class MyRememberInfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRememberTenantDb")));
            //services.AddScoped<IAuthDbContext, AuthDbContext>();

            return services;

        }
    }
}
