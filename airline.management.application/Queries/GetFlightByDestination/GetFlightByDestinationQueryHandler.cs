using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetFlightByDestination
{
    public class GetFlightByDestinationQueryHandler : IRequestHandler<GetFlightByDestinationQuery, List<FlightDetailsDto>>
    {
        private readonly IFlightDetailServices _flightDetailServices;

        public GetFlightByDestinationQueryHandler(IFlightDetailServices flightDetailServices)
        {
            _flightDetailServices = flightDetailServices;
        }

        public async Task<List<FlightDetailsDto>> Handle(GetFlightByDestinationQuery request, CancellationToken cancellationToken)
        {
            var flight = await _flightDetailServices.GetFlightByDestination(request.Departure, request.Arrival);

            return flight;
        }
    }
}
