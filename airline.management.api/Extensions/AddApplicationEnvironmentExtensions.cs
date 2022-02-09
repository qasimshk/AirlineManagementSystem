using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace airline.management.api.Extensions
{
    public static class AddApplicationEnvironmentExtensions
    {
        public static IApplicationBuilder AddApplicationEnvironment(this IApplicationBuilder applicationBuilder, IWebHostEnvironment env, string applicationName)
        {
            if (env.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", applicationName));

            return applicationBuilder;
        }
    }
}
