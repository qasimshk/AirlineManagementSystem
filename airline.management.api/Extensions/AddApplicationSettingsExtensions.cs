﻿using airline.management.api.Configurations;
using airline.management.api.Filters;
using airline.management.infrastructure.BusinessProcess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace airline.management.api.Extensions
{
    public static class AddApplicationSettingsExtensions
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration, string applicationName)
        {
            services.AddControllers()
               .AddFluentValidation()
               .AddNewtonsoftJson();

            services.AddOptions();

            services.Configure<ServicesEndpoints>(configuration.GetSection(nameof(ServicesEndpoints)));

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = applicationName, Version = "v1" });
                
                c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme.ToLowerInvariant(),
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                
                c.OperationFilter<AuthResponsesOperationFilter>();
            });

            services.AddHealthChecks();

            return services;
        }
    }    
}
