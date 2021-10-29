using airline.management.abstractions.Failed;
using System;

namespace airline.payment.service.Events
{
    public class FailedEvent : IFailedEvent
    {
        public string ConsumerName { get; set; }
        public string ErrorMessage { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
