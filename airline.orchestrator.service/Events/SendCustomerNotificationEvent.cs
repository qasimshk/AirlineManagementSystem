using airline.management.abstractions.Customers;
using airline.management.abstractions.Notifications;
using System;

namespace airline.orchestrator.service.Events
{
    public class SendCustomerNotificationEvent : ISendCustomerNotificationEvent
    {
        private readonly ICreateOrUpdateCustomerEvent _customer;

        public SendCustomerNotificationEvent(ICreateOrUpdateCustomerEvent customer)
        {
            _customer = customer;
            CorrelationId = _customer.CorrelationId;
        }

        public string FirstName => _customer.FirstName;
        public string LastName => _customer.LastName;
        public string EmailAddress => _customer.EmailAddress;
        public Guid CorrelationId { get; set; }
    }
}
