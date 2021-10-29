using airline.management.abstractions.Base;

namespace airline.management.abstractions.Orders
{
    public interface ITicketDetailRequestEvent : IBaseEvent
    {
        string TicketNumber { get; set; }
    }
}
