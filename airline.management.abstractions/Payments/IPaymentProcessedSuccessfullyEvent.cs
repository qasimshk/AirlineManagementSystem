using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Payments
{
    public interface IPaymentProcessedSuccessfullyEvent : IBaseEvent
    {
        Guid PaymentId { get; set; }
    }
}
