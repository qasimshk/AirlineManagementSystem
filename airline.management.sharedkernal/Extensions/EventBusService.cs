using airline.management.sharedkernal.Configurations;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace airline.management.sharedkernal.Extensions
{
    public static class EventBusService
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationConfig>>().Value;

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(cfg =>
            {
                cfg.AddBusConfigurator(appConfig.EventBusConnection);
            });

            return services;
        }
    }
}
