using airline.management.abstractions.Customers;
using System;

namespace airline.management.domain.Events
{
    public class CustomerDetailRequest : ICustomerDetailRequest
    {
        public Guid CorrelationId { get; set; }
    }
}
