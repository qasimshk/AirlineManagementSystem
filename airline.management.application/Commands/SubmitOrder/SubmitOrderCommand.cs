using airline.management.application.Models;
using MediatR;
using System;

namespace airline.management.application.Commands.SubmitOrder
{
    public class SubmitOrderCommand : IRequest<OrderSubmittedDto>
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }        
    }
}
