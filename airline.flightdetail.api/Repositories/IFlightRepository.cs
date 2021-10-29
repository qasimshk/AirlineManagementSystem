using airline.flightdetail.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<FlightDetailsDto>> GetAllFlights();
        Task<IEnumerable<FlightDetailsDto>> GetFlightDetails(string departure, string arrival);
        Task<FlightDetailsDto> GetFlightDetailsByFlightNumber(string flightNumber);
    }
}
