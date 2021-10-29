using airline.management.abstractions.Customers;
using airline.management.application.Abstractions.Services;
using airline.management.domain.Events;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRequestClient<ICustomerDetailRequest> _customerDetailRequest;

        public CustomerService(IRequestClient<ICustomerDetailRequest> customerDetailRequest)
        {
            _customerDetailRequest = customerDetailRequest;
        }

        public async Task<CustomerDetailsEvent> GetCustomerDetails(Guid correlationId)
        {
            var response = await _customerDetailRequest.GetResponse<ICustomerDetailsResult>(new CustomerDetailRequest 
            { 
                CorrelationId = correlationId
            });

            return new CustomerDetailsEvent
            {
                CorrelationId = response.Message.CorrelationId,
                EmailAddress = response.Message.EmailAddress,
                FirstName = response.Message.FirstName,
                LastName = response.Message.LastName
            };
        }
    }
}
