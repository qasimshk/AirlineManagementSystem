using airline.management.abstractions.Customers;
using System;

namespace airline.customers.service.Events
{
    public class CustomerProcessedSuccessfullyEvent : ICustomerProcessedSuccessfullyEvent
    {
        public Guid CustomerId { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
