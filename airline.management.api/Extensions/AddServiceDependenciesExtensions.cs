using airline.management.api.Behaviours;
using airline.management.application.Queries.GetCountries;
using airline.management.application.Queries.GetFlightByDestination;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace airline.management.api.Extensions
{
    public static class AddServiceDependenciesExtensions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(typeof(GetFlightByDestinationQueryValidator).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetCountriesQueryHandler).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            //DI
            //services.Scan(scan => scan
            //    .FromAssemblyOf<FlightDetailServices>()
            //    .AddClasses()
            //    .AsImplementedInterfaces()
            //    .WithTransientLifetime());

            return services;
        }
    }
}
