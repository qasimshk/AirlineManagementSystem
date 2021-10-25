using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDetailsDto>>
    {
        private readonly IFlightDetailServices _flightDetailServices;

        public GetCountriesQueryHandler(IFlightDetailServices flightDetailServices)
        {
            _flightDetailServices = flightDetailServices;
        }

        public Task<List<CountryDetailsDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = _flightDetailServices.GetAllCountry();

            return countries;
        }
    }
}
