using airline.flightdetail.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryDetailsDto>> Get();
    }
}
