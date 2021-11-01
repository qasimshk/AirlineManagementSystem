using System;

namespace airline.management.abstractions.Payments
{
    public interface ITicketPaymentDetailsRequestEvent 
    {
        Guid PaymentReference { get; set; }
    }
}
