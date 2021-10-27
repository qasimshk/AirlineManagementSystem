using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Payments
{
    public interface IPaymentProcessedSuccessfully : IBaseEvent
    {
        Guid PaymentId { get; set; }
    }
}
