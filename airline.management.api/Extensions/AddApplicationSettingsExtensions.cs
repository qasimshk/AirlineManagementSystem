using airline.management.api.Configurations;
using airline.management.api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace airline.management.api.Extensions
{
    public static class AddApplicationSettingsExtensions
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration, string applicationName)
        {
            services.AddControllers(options =>
                   options.Filters.Add<ApiExceptionFilterAttribute>())
               .AddFluentValidation()
               .AddNewtonsoftJson();

            services.AddOptions();

            services.Configure<ServicesEndpoints>(configuration.GetSection(nameof(ServicesEndpoints)));

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = applicationName, Version = "v1" });
            });

            return services;
        }
    }
}
