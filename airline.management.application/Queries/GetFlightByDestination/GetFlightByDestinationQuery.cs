using airline.management.application.Models;
using MediatR;

namespace airline.management.application.Queries.GetFlightByDestination
{
    public class GetFlightByDestinationQuery : IRequest<FlightDetailsDto> 
    {
        public GetFlightByDestinationQuery(string departure, string arrival)
        {
            Departure = departure.ToUpper();
            Arrival = arrival.ToUpper();
        }

        public string Departure { get; }
        public string Arrival { get; }
    }
}
