﻿using airline.management.sharedkernal.Configurations;
using airline.management.sharedkernal.Extensions;
using airline.notification.service.Consumers;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace airline.notification.service.Extensions
{
    public static class AddEventBusServiceExtensions
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationConfig>>().Value;

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumersFromNamespaceContaining<NotificationConsumer>();

                cfg.AddBusConfigurator(appConfig);
            });

            return services;
        }
    }
}
