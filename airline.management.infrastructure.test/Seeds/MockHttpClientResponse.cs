using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace airline.management.infrastructure.test.Seeds
{
    public static class MockHttpClientResponse
    {
        public static HttpClient SetHttpClientResponse(object response, HttpStatusCode responseStatus)
        {
            var httpClient = new HttpClient(new FakeHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response)),
                    StatusCode = responseStatus                     
                };

                return await Task.FromResult(responseMessage);
            }));

            httpClient.BaseAddress = new Uri("https://localhost/api/");

            return httpClient;
        }
    }
}
