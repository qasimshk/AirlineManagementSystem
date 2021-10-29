using airline.management.abstractions.Customers;
using airline.management.sharedkernal.Abstractions;
using airline.management.sharedkernal.Common;
using System;

namespace airline.customers.service.Entities
{
    public class Customers : BaseEntity, ICreateOrUpdateCustomerEvent, IAggregateRoot
    {
        public Guid CustomerRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
