using airline.management.api.Extensions;
using airline.management.infrastructure.Persistence.Context;
using airline.management.sharedkernal.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace airline.management.api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private const string applicationName = "Airline Management System";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplicationSettings(_configuration, applicationName)
                .AddApplicationDbContext<GatewayDbContext>(_configuration)
                .AddIdentitySettings(_configuration)
                .AddServiceConfiguration(_configuration)
                .AddInternalServices()
                .AddServiceDependencies()                
                .AddEventBusService();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
              .AddApplicationEnvironment(env, applicationName)
              .AddApplicationConfiguration();            
        }
    }
}
