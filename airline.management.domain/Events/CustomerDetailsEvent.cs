using airline.management.abstractions.Customers;
using System;

namespace airline.management.domain.Events
{
    public class CustomerDetailsEvent : ICreateOrUpdateCustomerEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
