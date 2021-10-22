using airline.flightdetail.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Repositories
{
    public interface IFlightRepository
    {
        public Task<IEnumerable<FlightDetailsDto>> GetAllFlights();

        public Task<FlightDetailsDto> GetFlightDetails(string departure, string arrival);        
    }
}
