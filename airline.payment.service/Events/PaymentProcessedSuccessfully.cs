using airline.management.abstractions.Payments;
using System;

namespace airline.payment.service.Events
{
    public class PaymentProcessedSuccessfully : IPaymentProcessedSuccessfully
    {
        public Guid PaymentId { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
