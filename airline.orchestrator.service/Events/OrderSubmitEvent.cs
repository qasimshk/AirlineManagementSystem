using airline.management.abstractions.API;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Orders;
using System;

namespace airline.orchestrator.service.Events
{
    public class OrderSubmitEvent : IOrderSubmitEvent
    {
        public OrderSubmitEvent()
        {
            Customer = new CreateOrUpdateCustomerEvent();
            Ticket = new CreateFlightTicketEvent();
        }

        public ICreateOrUpdateCustomerEvent Customer { get; set; }
        public ICreateFlightTicketEvent Ticket { get; set; }
        public double TicketPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
