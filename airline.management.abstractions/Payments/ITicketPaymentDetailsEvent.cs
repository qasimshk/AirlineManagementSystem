using airline.management.abstractions.Base;

namespace airline.management.abstractions.Payments
{
    public interface ITicketPaymentDetailsEvent : IBaseEvent
    {
        double Amount { get; set; }
    }
}
