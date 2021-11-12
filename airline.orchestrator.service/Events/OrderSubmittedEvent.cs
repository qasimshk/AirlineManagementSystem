using airline.management.abstractions.Orders;
using System;

namespace airline.orchestrator.service.Events
{
    public class OrderSubmittedEvent : IOrderSubmittedEvent
    {
        public Guid CorrelationId { get; set; }
        public string Customer { get; set; }
        public string EmailAddress { get; set; }        
        public string OrderDate { get; set; }
        public string Status { get; set; }
    }
}
