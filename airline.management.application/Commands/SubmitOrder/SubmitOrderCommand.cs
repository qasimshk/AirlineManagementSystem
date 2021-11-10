using airline.management.application.Models;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace airline.management.application.Commands.SubmitOrder
{
    public class SubmitOrderCommand : IRequest<OrderSubmittedDto>
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }                
    }
}
