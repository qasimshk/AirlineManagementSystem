using System;

namespace airline.management.abstractions.Orders
{
    public interface IOrderSubmittedEvent
    {
        Guid CorrelationId { get; set; }
        string Customer { get; set; }
        string EmailAddress { get; set; }        
        string OrderDate { get; set; }
        string Status { get; set; }
    }
}
