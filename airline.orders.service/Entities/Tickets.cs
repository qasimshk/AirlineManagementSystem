using airline.management.abstractions.Orders;
using airline.management.sharedkernal.Abstractions;
using airline.management.sharedkernal.Common;
using System;

namespace airline.orders.service.Entities
{
    public class Tickets : BaseEntity, ICreateFlightTicketEvent, IAggregateRoot
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureCountry { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCountry { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid OrderRef { get; set; }
        public string TicketNumber { get; set; }
    }
}
