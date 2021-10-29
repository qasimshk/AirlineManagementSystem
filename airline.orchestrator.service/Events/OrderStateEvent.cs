using airline.management.abstractions.Orders;
using System;

namespace airline.orchestrator.service.Events
{
    public class OrderStateEvent : IOrderStateEvent
    {
        public string TicketNumber { get; set; }
        public string TicketPrice { get; set; }
        public string CurrentState { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string PaymentId { get; set; }
        public string CreatedOn { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
