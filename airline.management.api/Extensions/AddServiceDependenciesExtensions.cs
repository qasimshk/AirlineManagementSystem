﻿using airline.management.api.Behaviours;
using airline.management.application.Abstractions.Mappers;
using airline.management.application.Abstractions.Services;
using airline.management.application.Mappers;
using airline.management.application.Queries.GetCountries;
using airline.management.application.Queries.GetFlightByDestination;
using airline.management.infrastructure.Services;
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
            services.AddValidatorsFromAssembly(typeof(GetFlightByDestinationQueryValidator).GetTypeInfo().Assembly);

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetCountriesQueryHandler).GetTypeInfo().Assembly);            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<IOrchestratorService, OrchestratorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderMapper, OrderMapper>();

            return services;
        }
    }
}
