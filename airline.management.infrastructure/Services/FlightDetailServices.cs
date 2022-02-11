using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using airline.management.infrastructure.Extensions;
using airline.management.infrastructure.Url;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Services
{
    public class FlightDetailServices : IFlightDetailServices
    {
        private readonly HttpClient _httpClient;

        public FlightDetailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<List<CountryDetailsDto>> GetAllCountry()
        {
            var response = await _httpClient.GetAsync(FlightDetailOperations.GetAllCountries());
            return await response.ReadContentAs<List<CountryDetailsDto>>();
        }

        public async Task<List<FlightDetailsDto>> GetAvailableFlights()
        {
            var response = await _httpClient.GetAsync(FlightDetailOperations.GetAllAvailableFlights());
            return await response.ReadContentAs<List<FlightDetailsDto>>();
        }

        public async Task<List<FlightDetailsDto>> GetFlightByDestination(string departure, string arrival)
        {
            var response = await _httpClient.GetAsync(FlightDetailOperations.GetAvailableFlightByDestination(departure, arrival));
            return await response.ReadContentAs<List<FlightDetailsDto>>();
        }

        public async Task<FlightDetailsDto> GetFlightByFlightNumber(string flightNumber)
        {
            var response = await _httpClient.GetAsync(FlightDetailOperations.GetAvailableFlightByFlightNumber(flightNumber));
            return await response.ReadContentAs<FlightDetailsDto>();
        }
    }
}
