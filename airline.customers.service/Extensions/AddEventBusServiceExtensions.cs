using airline.customers.service.Consumers;
using airline.management.sharedkernal.Configurations;
using airline.management.sharedkernal.Extensions;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace airline.customers.service.Extensions
{
    public static class AddEventBusServiceExtensions
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationConfig>>().Value;

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumersFromNamespaceContaining<CustomerConsumer>();

                cfg.AddBusConfigurator(appConfig.EventBusConnection);                
            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
