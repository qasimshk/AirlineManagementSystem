using airline.management.abstractions.Payments;
using System;

namespace airline.payment.service.Events
{
    public class TicketPaymentDetails : ITicketPaymentDetailsEvent
    {
        public double Amount { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
