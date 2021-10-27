using airline.management.abstractions.Payments;
using System;

namespace airline.orchestrator.service.Events
{
    public class AddPaymentEvent : IAddPaymentEvent
    {
        public Guid OrderId { get; set; }
        public double Amount { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
