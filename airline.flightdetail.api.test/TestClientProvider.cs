using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace airline.flightdetail.api.test
{
    public class TestClientProvider
    {
        public readonly HttpClient TestClient;

        public TestClientProvider()
        {
            SetEnvironmentVariable();
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(Services =>
                    {
                        // Add & remove dependencies here.
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        private void SetEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        }
    }
}
