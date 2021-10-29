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

        public async Task<IEnumerable<FlightDetailsDto>> GetFlightDetails(string departure, string arrival)
        {
            var details = await _db.QueryAsync<FlightDetailsDto>(@"SELECT FlightNo	
                          ,DepartureAirport	
                          ,DepartureCountry	
                          ,DepartureCountryISO	
                          ,ArrivalAirport	
                          ,ArrivalCountry	
                          ,ArrivalCountryISO	
                          ,Distance	
                          ,ModelNumber	
                          ,ManufacturerName	
                          ,PlaneRange	
                          ,CruiseSpeed 
                          FROM vw_FlightDetails 
                          WHERE DepartureCountryISO=@Departure 
                          AND ArrivalCountryISO=@Arrival",
                          new
                          {
                              Departure = departure.ToUpper(),
                              Arrival = arrival.ToUpper()
                          }, commandType: CommandType.Text);

            return details.ToList();
        }

        public async Task<FlightDetailsDto> GetFlightDetailsByFlightNumber(string flightNumber)
        {
            var details = await _db.QueryAsync<FlightDetailsDto>("sp_GetFlightByFlightNumber", new
            {
                FlightNumber = flightNumber
            }, commandType: CommandType.StoredProcedure);

            return details.SingleOrDefault();
        }
    }
}
