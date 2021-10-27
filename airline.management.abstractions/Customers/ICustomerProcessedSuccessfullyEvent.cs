using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Customers
{
    public interface ICustomerProcessedSuccessfullyEvent : IBaseEvent
    {
        Guid CustomerId { get; set; }
    }
}
