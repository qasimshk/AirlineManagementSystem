﻿using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetTicketDetails
{
    public class GetTicketDetailsQueryHandler : IRequestHandler<GetTicketDetailsQuery, CustomerTicketDto>
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public GetTicketDetailsQueryHandler(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        public async Task<CustomerTicketDto> Handle(GetTicketDetailsQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _orderService.GetTicketDetails(request.TicketNumber, request.OrderNumber);

            var customer = await _customerService.GetCustomerDetails(Guid.Parse(request.OrderNumber));

            return new CustomerTicketDto
            {
                FlightNumber = ticket.FlightNumber,
                TicketNumber = request.TicketNumber,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Departure = new FlightDetails
                {
                    Airport = ticket.DepartureAirport,
                    Country = ticket.DepartureCountry,
                    FlightgDate = ticket.DepartureDate.ToString("d")
                },
                Arrival = new FlightDetails
                {
                    Airport = ticket.ArrivalAirport,
                    Country = ticket.ArrivalCountry,
                    FlightgDate = ticket.ArrivalDate.ToString("d")
                }
            };            
        }
    }
}
