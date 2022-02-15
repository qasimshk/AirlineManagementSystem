using airline.management.api.Configurations;
using airline.management.application.Abstractions.Services;
using airline.management.infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace airline.management.api.Extensions
{
    public static class AddInternalServicesExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            var appConfig = services.BuildServiceProvider().GetRequiredService<IOptions<ServicesEndpoints>>().Value;

            services.AddHttpClient<IFlightDetailServices, FlightDetailServices>(cfg =>
            {
                cfg.BaseAddress = new Uri(appConfig.FlightDetailsURL);
                cfg.DefaultRequestHeaders.Accept.Clear();
                cfg.DefaultRequestHeaders.Add("Accept", "application/json");
            }).ConfigurePrimaryHttpMessageHandler(() =>
                {
                    var handler = new HttpClientHandler();
                    if (bool.TryParse(appConfig.IgnoreSsl.ToString(),
                            out var ignoreSslCertificateErrors) && ignoreSslCertificateErrors)
                        handler.ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    return handler;
                }).AddPolicyHandler((serviceProvider, _) => GetTimeOutPolicy(serviceProvider, appConfig.TimeOutForRetriesInSeconds))
                  .AddPolicyHandler((serviceProvider, _) => GetWaitAndRetryPolicy(serviceProvider, appConfig.RetryAttempts));

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetTimeOutPolicy(IServiceProvider serviceProvider, int maxTimeOutSeconds)
        {
            return Policy.TimeoutAsync<HttpResponseMessage>(maxTimeOutSeconds, (context, timeout, _, exception) =>
            {
                var logger = serviceProvider.GetService<ILogger<FlightDetailServices>>();
                logger?.LogError(
                    "Timeout and exception thrown is {{exception}}",
                    exception);
                return Task.CompletedTask;
            });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetWaitAndRetryPolicy(IServiceProvider serviceProvider, int retryTimes)
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), retryTimes);
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(s => s.StatusCode == HttpStatusCode.BadRequest)
                .WaitAndRetryAsync(delay, (outcome, timespan, retryAttempt, context) =>
                {
                    var logger = serviceProvider.GetService<ILogger<FlightDetailServices>>();
                    logger?.LogError(
                        "Retry on {{outcome.Result}} and exception thrown is {{outcome.Exception}}",
                        outcome.Result, outcome.Exception);
                });
        }
    }
}
