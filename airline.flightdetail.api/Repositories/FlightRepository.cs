using airline.flightdetail.api.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbConnection _db;

        public FlightRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FlightDetailsDto>> GetAllFlights()
        {
            return await _db.QueryAsync<FlightDetailsDto>("sp_GetAllFlights", commandType: CommandType.StoredProcedure);
        }

        public async Task<FlightDetailsDto> GetFlightDetails(string departure, string arrival)
        {
            var details = await _db.QueryAsync<FlightDetailsDto>("sp_GetFlightByDestination", new 
            {
                Departure = departure.ToUpper(),
                Arrival = arrival.ToUpper()
            }, commandType: CommandType.StoredProcedure);

            return details.SingleOrDefault();
        }
    }
}
