using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;

namespace airline.management.application.Queries.GetAvailableFlights
{
    public class GetAvailableFlightsQuery : IRequest<List<FlightDetailsDto>> { }
}
