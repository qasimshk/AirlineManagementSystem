using airline.management.abstractions.API;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Orders;
using System;

namespace airline.management.domain.Events
{
    public class OrderSubmitEvent : IOrderSubmitEvent
    {
        public OrderSubmitEvent()
        {
            Customer = new CustomerDetailsdsfsdfEvent();
            Ticket = new CreateFlightTicketEvent();
        }

        public ICreateOrUpdateCustomerEvent Customer { get; set; }
        public ICreateFlightTicketEvent Ticket { get; set; }
        public double TicketPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CorrelationId { get; set; }
    }

    public class CustomerDetailsdsfsdfEvent : ICreateOrUpdateCustomerEvent
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CorrelationId { get; set; }
    }

    public class CreateFlightTicketEvent : ICreateFlightTicketEvent
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
