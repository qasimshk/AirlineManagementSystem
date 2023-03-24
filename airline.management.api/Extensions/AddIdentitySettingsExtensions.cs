using airline.management.api.Configurations;
using airline.management.infrastructure.BusinessProcess;
using airline.management.infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace airline.management.api.Extensions
{
    public static class AddIdentitySettingsExtensions
    {
        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = services.BuildServiceProvider().GetRequiredService<IOptions<JwtConfig>>().Value;

            var identityconfiguration = configuration.GetSection(nameof(IdentityConfiguration)).Get<IdentityConfiguration>();

            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,                
                ValidateLifetime = true, // Token expired date will be verified it is set to TRUE
                ClockSkew = TimeSpan.Zero                
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

            services.AddAuthorization(options => 
            {
                options.AddPolicy("UserPermission", o => 
                {
                    o.RequireClaim(ClaimTypes.Role, "Manager");
                    o.RequireClaim("Nature", "Innocent");
                });
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
