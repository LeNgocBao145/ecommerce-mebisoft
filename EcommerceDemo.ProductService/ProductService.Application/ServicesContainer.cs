using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Behaviors;
using ProductService.Application.Mappings;
using System.Reflection;

namespace ProductService.Application
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //validation
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
