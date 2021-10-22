using airline.flightdetail.api.Models;
using airline.flightdetail.api.Repositories;
using airline.management.sharedkernal.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace airline.flightdetail.api.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IFlightRepository _flightRepository;

        public BookingController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        
        [HttpGet("AvailableFlights")]
        [ProducesResponseType(typeof(FlightDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AvailableFlights()
        {
            var details = await _flightRepository.GetAllFlights();

            return Ok(details.OrderBy(x => x.DepartureCountry));
        }

        [HttpGet("Search/{departure}/To/{arrival}")]        
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadGateway)]
        [ProducesResponseType(typeof(FlightDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Search(string departure, string arrival)
        {
            if(departure.Length > 3)
            {
                return BadRequest("Invalid departure country ISO code");
            }

            if (arrival.Length > 3)
            {
                return BadRequest("Invalid arrival country ISO code");
            }

            var details = await _flightRepository.GetFlightDetails(departure, arrival);

            return details is null ? NotFound("No flights found for specified destination") : Ok(details);
        }
    }
}
