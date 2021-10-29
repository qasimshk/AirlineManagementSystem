using airline.management.application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airline.management.application.Abstractions.Services
{
    public interface IFlightDetailServices
    {
        Task<List<CountryDetailsDto>> GetAllCountry();
        Task<List<FlightDetailsDto>> GetAvailableFlights();
        Task<List<FlightDetailsDto>> GetFlightByDestination(string departure, string arrival);
        Task<FlightDetailsDto> GetFlightByFlightNumber(string flightNumber);
    }
}
