using airline.management.abstractions.Orders;
using System;

namespace airline.orders.service.Events
{
    public class TicketCreatedSuccessfullyEvent : ITicketCreatedSuccessfullyEvent
    {
        public Guid OrderId { get; set; }
        public string TicketNumber { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
