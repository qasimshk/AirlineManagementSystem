using airline.customers.service.Events;
using airline.customers.service.Persistence.Repositories.Abstractions;
using airline.management.abstractions.Customers;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace airline.customers.service.Consumers
{
    public class CustomerDetailsConsumer : IConsumer<ICustomerDetailRequest>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDetailsConsumer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Consume(ConsumeContext<ICustomerDetailRequest> context)
        {
            var customer = (await _customerRepository.FindByConditionAsync(c => c.CorrelationId == context.Message.CorrelationId)).Single();

            await context.RespondAsync<ICustomerDetailsResult>(new CustomerDetailsResult
            {
               CorrelationId = context.Message.CorrelationId,
               EmailAddress = customer.EmailAddress,
               FirstName = customer.FirstName,
               LastName = customer.LastName,
            });
        }
    }
}
