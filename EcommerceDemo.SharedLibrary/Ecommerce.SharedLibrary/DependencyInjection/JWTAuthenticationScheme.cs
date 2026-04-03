using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecommerce.SharedLibrary.DependencyInjection
{
    public static class JWTAuthenticationScheme
    {
        public static IServiceCollection AddJwtAuthenticationScheme(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer("Bearer", options =>
            {
                var secretKey = Encoding.UTF8.GetBytes(config.GetSection("Authentication:Key").Value!);
                var issuer = config.GetSection("Authentication:Issuer").Value;
                var audience = config.GetSection("Authentication:Audience").Value;

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                };
            });
            return services;
        }
    }
}
