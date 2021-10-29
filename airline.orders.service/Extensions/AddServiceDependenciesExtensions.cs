using airline.orders.service.Persistence.Repositories.Abstractions;
using airline.orders.service.Persistence.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace airline.orders.service.Extensions
{
    public static class AddServiceDependenciesExtensions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
