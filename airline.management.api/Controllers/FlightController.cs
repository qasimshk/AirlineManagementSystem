﻿using airline.management.application.Commands.SubmitOrder;
using airline.management.application.Models;
using airline.management.application.Queries.GetAvailableFlights;
using airline.management.application.Queries.GetCountries;
using airline.management.application.Queries.GetFlightByDestination;
using airline.management.application.Queries.GetOrderState;
using airline.management.application.Queries.GetTicketDetails;
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
        [ProducesResponseType(typeof(List<FlightDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Destination([FromRoute] string departure, [FromRoute] string arrival)
        {
            return Ok(await _mediator.Send(new GetFlightByDestinationQuery(departure, arrival)));
        }

        [HttpGet("Order/State/{orderNumber}")]
        [ProducesResponseType(typeof(OrderStateDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> OrderState([FromRoute] string orderNumber)
        {
            if (string.IsNullOrEmpty(orderNumber)) return BadRequest("Order number is required");

            return Ok(await _mediator.Send(new GetOrderStateQuery(orderNumber)));
        }

        [HttpGet("Ticket/{ticketNumber}/{orderNumber}")]
        [ProducesResponseType(typeof(CustomerTicketDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Ticket([FromRoute] string ticketNumber, string orderNumber)
        {
            if (string.IsNullOrEmpty(orderNumber) && string.IsNullOrEmpty(ticketNumber) ) return BadRequest("Order & ticket number is required");

            return Ok(await _mediator.Send(new GetTicketDetailsQuery(ticketNumber, orderNumber)));
        }

        [HttpPost("BookingTicket")]
        [ProducesResponseType(typeof(OrderSubmittedDto), (int)HttpStatusCode.OK)]        
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BookingTicket([FromBody] SubmitOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
