using airline.management.abstractions.Customers;
using System;

namespace airline.customers.service.Events
{
    public class CustomerDetailsResult : ICustomerDetailsResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
