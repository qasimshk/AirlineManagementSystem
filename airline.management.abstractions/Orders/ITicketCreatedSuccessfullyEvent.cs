using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Orders
{
    public interface ITicketCreatedSuccessfullyEvent : IBaseEvent
    {
        Guid OrderId { get; set; }
    }
}
