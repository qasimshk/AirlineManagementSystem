using airline.management.abstractions.API;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Orders;
using airline.management.abstractions.Payments;
using airline.management.sharedkernal.Configurations;
using airline.management.sharedkernal.Extensions;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace airline.management.api.Extensions
{
    public static class AddEventBusServiceExtensions
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationConfig>>().Value;

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(cfg =>
            {
                cfg.ApplyCustomMassTransitConfiguration();

                cfg.SetKebabCaseEndpointNameFormatter();

                cfg.AddBusConfigurator(appConfig.EventBusConnection);

                cfg.AddRequestClient<IOrderStateRequestEvent>();

                cfg.AddRequestClient<ICustomerDetailRequest>();

                cfg.AddRequestClient<ITicketDetailRequestEvent>();

                cfg.AddRequestClient<ITicketPaymentDetailsRequestEvent>();

                cfg.AddRequestClient<IOrderSubmitEvent>();                
            });

            // Required for Request & Response Client
            services.AddMassTransitHostedService();

            return services;
        }
    }
}
