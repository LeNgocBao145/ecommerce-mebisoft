using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Ecommerce.SharedLibrary.DependencyInjection
{
    public static class SharedServicesContainer
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services,
            IConfiguration config, string fileName)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(path: $"{fileName}-.text",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day
                ).CreateLogger();

            JWTAuthenticationScheme.AddJwtAuthenticationScheme(services, config);

            return services;
        }
    }
}
