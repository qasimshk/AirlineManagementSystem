using airline.management.sharedkernal.Configurations;
using airline.management.sharedkernal.Extensions;
using airline.orchestrator.service.Entities;
using airline.orchestrator.service.Persistence.Context;
using airline.orchestrator.service.WorkFlow;
using MassTransit;
using MassTransit.Definition;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace airline.orchestrator.service.Extensions
{
    public static class AddEventBusExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationConfig>>().Value;

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(cfg =>
            {
                cfg.AddSagaStateMachine<ServiceStateMachine, ServiceTransactions>()
                    .EntityFrameworkRepository(ef =>
                    {
                        ef.ConcurrencyMode = ConcurrencyMode.Pessimistic;
                        ef.AddDbContext<DbContext, StateDbContext>((provider, builder) =>
                        {
                            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                            {
                                sqlOptions.MigrationsHistoryTable($"__{nameof(StateDbContext)}");
                            });
                        });
                    });

                cfg.AddBusConfigurator(appConfig);
            });

            return services;
        }
    }
}
