using airline.management.abstractions.Orders;
using System;

namespace airline.management.domain.Events
{
    public class TicketDetailEvent : ITicketDetailEvent
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureCountry { get; set; }
        public DateTime DepartureDate { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCountry { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
