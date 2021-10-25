using airline.management.api.Configurations;
using airline.management.application.Abstractions.Services;
using airline.management.infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace airline.management.api.Extensions
{
    public static class AddInternalServicesExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ServicesEndpoints>>().Value;

            services.AddHttpClient<IFlightDetailServices, FlightDetailServices>(cfg =>
            {
                cfg.BaseAddress = new Uri(appConfig.FlightDetailsURL);
                cfg.DefaultRequestHeaders.Accept.Clear();
                cfg.DefaultRequestHeaders.Add("Accept", "application/json");
            });
               
            return services;
        }
    }
}
