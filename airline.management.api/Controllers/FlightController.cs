using airline.management.application.Models;
using airline.management.application.Queries.GetAvailableFlights;
using airline.management.application.Queries.GetCountries;
using airline.management.application.Queries.GetFlightByDestination;
using airline.management.sharedkernal.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace airline.management.api.Controllers
{
    public class FlightController : BaseController
    {
        [HttpGet("Countries")]
        [ProducesResponseType(typeof(List<CountryDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Countries()
        {
            return Ok(await _mediator.Send(new GetCountriesQuery()));
        }

        [HttpGet("Available")]
        [ProducesResponseType(typeof(List<FlightDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Available()
        {
            return Ok(await _mediator.Send(new GetAvailableFlightsQuery()));
        }

        [HttpGet("Destination/{departure}/To/{arrival}")]
        [ProducesResponseType(typeof(FlightDetailsDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Destination(string departure, string arrival)
        {
            return Ok(await _mediator.Send(new GetFlightByDestinationQuery(departure, arrival)));
        }
    }
}
