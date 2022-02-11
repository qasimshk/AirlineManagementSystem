using airline.management.sharedkernal.Configurations;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using System;

namespace airline.management.sharedkernal.Extensions
{
    public static class AddBusConfiguratorExtensions
    {
        public static IServiceCollectionBusConfigurator AddBusConfigurator(this IServiceCollectionBusConfigurator configurator, ApplicationConfig applicationConfig)
        {
            configurator.ApplyCustomMassTransitConfiguration();

            configurator.SetKebabCaseEndpointNameFormatter();

            configurator.UsingRabbitMq((context, rabbitMqBusFactoryConfigurator) =>
            {
                // if cloud amqp account is used then make sure to add user name as well after host name in config for example cloudamqp.example.com/jetzodxo:jetzodxo

                if (applicationConfig.EventBusConnection != string.Empty)
                {
                    rabbitMqBusFactoryConfigurator.Host(applicationConfig.EventBusConnection);
                }
                else
                {
                    rabbitMqBusFactoryConfigurator.Host(new Uri($"rabbitmq://{applicationConfig.EventBusHost}/"), hostConfigurator =>
                    {
                        hostConfigurator.Username(applicationConfig.EventBusUser);
                        hostConfigurator.Password(applicationConfig.EventBusPassword);
                    });
                }

                MessageDataDefaults.ExtraTimeToLive = TimeSpan.FromDays(1);
                MessageDataDefaults.Threshold = 2000;
                MessageDataDefaults.AlwaysWriteToRepository = false;

                rabbitMqBusFactoryConfigurator.ConfigureEndpoints(context);
            });

            return configurator;
        }
    }
}
