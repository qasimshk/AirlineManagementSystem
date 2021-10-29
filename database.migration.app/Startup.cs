using airline.customers.service.Persistence.Context;
using airline.management.sharedkernal.Extensions;
using airline.orchestrator.service.Persistence.Context;
using airline.orders.service.Persistence.Context;
using airline.payment.service.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace database.migration.app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "database.migration.app", Version = "v1" });
            });

            // Orchestrator
            //services.AddApplicationDbContext<StateDbContext>(Configuration);

            // Customer
            //services.AddApplicationDbContext<CustomerDbContext>(Configuration);

            // Orders
            //services.AddApplicationDbContext<OrderDbContext>(Configuration);

            // Payments
            services.AddApplicationDbContext<PaymentDbContext>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "database.migration.app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
