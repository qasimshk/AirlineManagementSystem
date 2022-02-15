using airline.flightdetail.api.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace airline.flightdetail.api.test
{
    public class CountryControllerTest : IClassFixture<TestClientProvider>
    {
        private readonly TestClientProvider _testClientProvide;

        public CountryControllerTest(TestClientProvider testClientProvide)
        {
            _testClientProvide = testClientProvide;
        }

        [Fact]
        public async Task When_GET_Countries_Called_Expect_CountryDetailsDto_list()
        {
            // Act
            var response = await _testClientProvide.TestClient.GetAsync("api/country/all");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnedGet = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CountryDetailsDto>>(returnedGet, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            result.Should().BeOfType<List<CountryDetailsDto>>();
        }
    }
}
