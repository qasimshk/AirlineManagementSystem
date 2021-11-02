using airline.management.abstractions.Customers;
using airline.management.application.Abstractions.Services;
using airline.management.domain.Events;
using airline.management.domain.Exceptions;
using MassTransit;
using System;
using System.Threading;
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

        public async Task<CustomerDetailsEvent> GetCustomerDetails(Guid customerReferrence, CancellationToken cancellationToken)
        {
            var response = await _customerDetailRequest.GetResponse<ICustomerDetailsResult>(new CustomerDetailRequest 
            { 
                CustomerReferrence = customerReferrence
            }, cancellationToken);

            if (response == null) throw new NotFoundException("Record not found");

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
