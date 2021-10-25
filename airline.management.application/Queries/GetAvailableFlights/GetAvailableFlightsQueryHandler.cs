using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IRequestHandler<GetAvailableFlightsQuery, List<FlightDetailsDto>>
    {
        private readonly IFlightDetailServices _flightDetailServices;

        public GetAvailableFlightsQueryHandler(IFlightDetailServices flightDetailServices)
        {
            _flightDetailServices = flightDetailServices;
        }

        public async Task<List<FlightDetailsDto>> Handle(GetAvailableFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightDetailServices.GetAvailableFlights();

            return flights;
        }
    }
}
