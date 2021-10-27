using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using System;

namespace airline.management.sharedkernal.Extensions
{
    public static class AddBusConfiguratorExtensions
    {
        public static IServiceCollectionBusConfigurator AddBusConfigurator(this IServiceCollectionBusConfigurator configurator, string eventBusConnection)
        {
            configurator.ApplyCustomMassTransitConfiguration();

            configurator.SetKebabCaseEndpointNameFormatter();

            configurator.UsingRabbitMq((context, rabbitMqBusFactoryConfigurator) =>
            {
                rabbitMqBusFactoryConfigurator.Host(eventBusConnection);

                MessageDataDefaults.ExtraTimeToLive = TimeSpan.FromDays(1);
                MessageDataDefaults.Threshold = 2000;
                MessageDataDefaults.AlwaysWriteToRepository = false;

                rabbitMqBusFactoryConfigurator.ConfigureEndpoints(context);
            });

            return configurator;
        }
    }
}
