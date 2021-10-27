using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Payments
{
    public interface IAddPaymentEvent : IBaseEvent
    {
        Guid OrderId { get; set; }
        double Amount { get; set; }
    }
}
