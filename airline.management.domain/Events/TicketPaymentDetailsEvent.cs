using airline.management.abstractions.Payments;
using System;

namespace airline.management.domain.Events
{
    public class TicketPaymentDetailsEvent : ITicketPaymentDetailsEvent
    {
        public double Amount { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
