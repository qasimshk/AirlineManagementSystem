using airline.management.abstractions.Orders;
using System;

namespace airline.orchestrator.service.Events
{
    public class CreateFlightTicketEvent : ICreateFlightTicketEvent
    {
        public CreateFlightTicketEvent() { }

        public CreateFlightTicketEvent(ICreateFlightTicketEvent createFlightTicketEvent)
        {
            FlightNumber = createFlightTicketEvent.FlightNumber;
            CorrelationId = createFlightTicketEvent.CorrelationId;

            DepartureAirport = createFlightTicketEvent.DepartureAirport;
            DepartureCountry = createFlightTicketEvent.DepartureCountry;
            DepartureDate = createFlightTicketEvent.DepartureDate;

            ArrivalAirport = createFlightTicketEvent.ArrivalAirport;
            ArrivalCountry = createFlightTicketEvent.ArrivalCountry;
            ArrivalDate = createFlightTicketEvent.ArrivalDate;
        }

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
