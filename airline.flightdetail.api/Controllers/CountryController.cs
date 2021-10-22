using airline.flightdetail.api.Repositories;
using airline.management.sharedkernal.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using airline.flightdetail.api.Models;

namespace airline.flightdetail.api.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(CountryDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> All()
        {
            var countries = await _countryRepository.Get();

            return Ok(countries.OrderBy(x => x.CountryName));
        }
    }
}
