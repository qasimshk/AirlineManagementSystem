using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.api.test
{
    public class RetryPolicyTest
    {
        [Fact]
        public async Task Given_a_retry_policy_configured_on_a_named_client_When_call_via_the_named_client_Then_the_policy_is_used()
        {
            // Arrange 
            var services = new ServiceCollection();
            bool retryCalled = false;
            var codeHandledByPolicy = HttpStatusCode.InternalServerError;
            int numberOfRetries = 3;

            const string TestClient = "TestClient";
            services.AddHttpClient(TestClient)
                .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
                    .RetryAsync(numberOfRetries, onRetry: (_, __) => retryCalled = true))
                .AddHttpMessageHandler(() => new StubDelegatingHandler(codeHandledByPolicy));

            HttpClient configuredClient =
                services
                    .BuildServiceProvider()
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(TestClient);

            // Act
            var result = await configuredClient.GetAsync("https://www.ErrorUrl.com/");

            // Assert
            result.StatusCode.Should().Be(codeHandledByPolicy);

            retryCalled.Should().BeTrue();
        }
    }

    public class StubDelegatingHandler : DelegatingHandler
    {
        private readonly HttpStatusCode stubHttpStatusCode;
        public StubDelegatingHandler(HttpStatusCode stubHttpStatusCode) => this.stubHttpStatusCode = stubHttpStatusCode;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => Task.FromResult(new HttpResponseMessage(stubHttpStatusCode));
    }
}
