using airline.management.abstractions.Orders;
using System;

namespace airline.orchestrator.service.Events
{
    public class OrderStateRequestEvent : IOrderStateRequestEvent
    {
        public Guid CorrelationId { get; set; }
    }
}
