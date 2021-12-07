using MassTransit;

namespace airline.management.sharedkernal.Extensions
{
    public static class CustomConfigurationExtensions
    {        
        public static void ApplyCustomMassTransitConfiguration(this IBusRegistrationConfigurator configurator)
        {
            configurator.SetEndpointNameFormatter(new CustomEndpointNameFormatter());
        }
    }
}
