using airline.management.api.Configurations;
using airline.management.infrastructure.BusinessProcess;
using airline.management.infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace airline.management.api.Extensions
{
    public static class AddIdentitySettingsExtensions
    {
        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            var identityconfiguration = configuration.GetSection(nameof(IdentityConfiguration)).Get<IdentityConfiguration>();

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

            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = identityconfiguration.PasswordRequireDigit;
                options.Password.RequiredLength = identityconfiguration.PasswordRequiredLength;
                options.Password.RequireNonAlphanumeric = identityconfiguration.PasswordRequireNonAlphanumeric;
                options.Password.RequireUppercase = identityconfiguration.PasswordRequireUppercase;
                options.Password.RequireLowercase = identityconfiguration.PasswordRequireLowercase;
                options.Password.RequiredUniqueChars = identityconfiguration.PasswordRequiredUniqueChars;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = identityconfiguration.LockoutMaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = identityconfiguration.LockoutAllowedForNewUsers;

                // User settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = identityconfiguration.UserRequireUniqueEmail;
            });

            return services;
        }
    }
}
