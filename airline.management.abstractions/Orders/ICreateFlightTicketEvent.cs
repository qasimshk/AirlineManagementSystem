using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Orders
{
    public interface ICreateFlightTicketEvent : IBaseEvent
    {
        Guid OrderId { get; set; }
        string TicketNumber { get; set; }
        string FlightNumber { get; set; }
        string DepartureAirport { get; set; }
        string DepartureCountry { get; set; }
        DateTime DepartureDate { get; set; }        
        string ArrivalAirport { get; set; }
        string ArrivalCountry { get; set; }
        DateTime ArrivalDate { get; set; }        
    }
}
