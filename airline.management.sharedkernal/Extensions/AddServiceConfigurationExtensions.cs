using airline.management.sharedkernal.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace airline.management.sharedkernal.Extensions
{
    public static class AddServiceConfigurationExtensions
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationConfig>(configuration.GetSection(nameof(ApplicationConfig)));

            return services;
        }
    }
}
