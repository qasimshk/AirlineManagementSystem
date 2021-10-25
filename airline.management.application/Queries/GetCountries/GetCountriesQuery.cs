using airline.management.application.Models;
using MediatR;
using System.Collections.Generic;

namespace airline.management.application.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<List<CountryDetailsDto>> { }
}
