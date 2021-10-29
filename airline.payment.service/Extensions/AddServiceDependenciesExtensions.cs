using airline.payment.service.Persistence.Repositories.Abstractions;
using airline.payment.service.Persistence.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace airline.payment.service.Extensions
{
    public static class AddServiceDependenciesExtensions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
