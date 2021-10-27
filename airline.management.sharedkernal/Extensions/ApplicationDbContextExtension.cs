using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;

namespace airline.management.sharedkernal.Extensions
{
    public static class ApplicationDbContextExtension
    {
        public static IServiceCollection AddApplicationDbContext<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                if (string.IsNullOrEmpty(configuration.GetConnectionString("DefaultConnection")))
                {
                    throw new ArgumentNullException("SQL Server connection string now found");
                }

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            });

            services.AddScoped<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
