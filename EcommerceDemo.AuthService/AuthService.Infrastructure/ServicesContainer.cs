using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Persistence;
using AuthService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"),
                sqlserverOption => sqlserverOption.EnableRetryOnFailure()
            ));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
