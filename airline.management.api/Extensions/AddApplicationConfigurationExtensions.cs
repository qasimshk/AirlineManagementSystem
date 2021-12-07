using airline.management.api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace airline.management.api.Extensions
{
    public static class AddApplicationConfigurationExtensions
    {
        public static IApplicationBuilder AddApplicationConfiguration(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();

            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return applicationBuilder;
        }
    }
}
