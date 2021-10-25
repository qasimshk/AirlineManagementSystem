using airline.management.domain.Exceptions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundException(response.ReasonPhrase);

            if (!response.IsSuccessStatusCode)
               throw new ServiceException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
