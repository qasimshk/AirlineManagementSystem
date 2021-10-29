using airline.customers.service.Persistence.Repositories.Abstractions;
using airline.customers.service.Persistence.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace airline.customers.service.Extensions
{
    public static class AddServiceDependenciesExtensions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
