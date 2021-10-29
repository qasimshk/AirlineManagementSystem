using airline.management.abstractions.Orders;
using System;

namespace airline.management.domain.Events
{
    public class TicketDetailRequestEvent : ITicketDetailRequestEvent
    {
        public string TicketNumber { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
