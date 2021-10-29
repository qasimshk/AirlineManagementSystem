using airline.management.abstractions.Customers;
using System;

namespace airline.orchestrator.service.Events
{
    public class CreateOrUpdateCustomerEvent : ICreateOrUpdateCustomerEvent
    {
        public CreateOrUpdateCustomerEvent() { }

        public CreateOrUpdateCustomerEvent(ICreateOrUpdateCustomerEvent createOrUpdateCustomerEvent)
        {
            FirstName = createOrUpdateCustomerEvent.FirstName;
            LastName = createOrUpdateCustomerEvent.LastName;
            EmailAddress = createOrUpdateCustomerEvent.EmailAddress;
            CorrelationId = createOrUpdateCustomerEvent.CorrelationId;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
