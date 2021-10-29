using airline.management.abstractions.Orders;
using System;

namespace airline.management.domain.Events
{
    public class OrderStateRequestEvent : IOrderStateRequestEvent
    {
        public Guid CorrelationId { get; set; }
    }
}
