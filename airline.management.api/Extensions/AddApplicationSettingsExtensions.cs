using airline.management.api.Configurations;
using airline.management.api.Filters;
using airline.management.infrastructure.BusinessProcess;
using airline.management.infrastructure.Persistence.Context;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace airline.management.api.Extensions
{
    public static class AddApplicationSettingsExtensions
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration, string applicationName)
        {
            services.AddControllers(options =>
                   options.Filters.Add<ApiExceptionFilterAttribute>())
               .AddFluentValidation()
               .AddNewtonsoftJson();

            services.AddOptions();

            services.Configure<ServicesEndpoints>(configuration.GetSection(nameof(ServicesEndpoints)));

            services.AddControllers();

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false
            };

            services.AddSingleton(tokenValidationParams);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParams;
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<GatewayDbContext>();

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

            return services;
        }
    }    
}
