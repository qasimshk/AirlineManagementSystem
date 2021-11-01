using airline.management.abstractions.Payments;
using System;

namespace airline.management.domain.Events
{
    public class TicketPaymentDetailsRequestEvent : ITicketPaymentDetailsRequestEvent
    {   
        public Guid PaymentReference { get; set; }
    }
}
