using AuthService.Application.Interfaces;
using AuthService.Application.Mappings;
using AuthService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
