using airline.customers.service.Entities;
using airline.customers.service.Events;
using airline.customers.service.Persistence.Repositories.Abstractions;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Failed;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace airline.customers.service.Consumers
{
    public class CustomerConsumer : IConsumer<ICreateOrUpdateCustomerEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerConsumer> _logger;

        public CustomerConsumer(ICustomerRepository customerRepository, ILogger<CustomerConsumer> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ICreateOrUpdateCustomerEvent> context)
        {
            try
            {
                _logger.LogInformation("Customer event received");
                
                var entity = new Customers
                {
                    CorrelationId = context.Message.CorrelationId,
                    EmailAddress = context.Message.EmailAddress,
                    FirstName = context.Message.FirstName,
                    LastName = context.Message.LastName,
                    CustomerRef = Guid.NewGuid()
                };

                var customer = await _customerRepository.FindByConditionAsync(c => c.EmailAddress == context.Message.EmailAddress);
                
                if(customer.Any())
                {
                    var updateEntity = customer.Single();

                    if (updateEntity.FirstName != entity.FirstName) updateEntity.FirstName = entity.FirstName;

                    if (updateEntity.LastName != entity.LastName) updateEntity.LastName = entity.LastName;

                    entity.CustomerRef = updateEntity.CustomerRef;

                    _customerRepository.Update(updateEntity);
                }
                else
                {
                    _customerRepository.Add(entity);
                }
                                
                await _customerRepository.UnitOfWork.SaveEntitiesAsync();
                _logger.LogInformation("Customer record processed successfully");

                await context.RespondAsync<ICustomerProcessedSuccessfullyEvent>(new CustomerProcessedSuccessfullyEvent
                {
                    CustomerId = entity.CustomerRef,
                    CorrelationId = context.Message.CorrelationId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Service was not able to save customer details");                

                await context.RespondAsync<IFailedEvent>(new FailedEvent
                {
                    ConsumerName = nameof(CustomerConsumer),
                    ErrorMessage = ex.ToString(),
                    CorrelationId = context.Message.CorrelationId
                });
            }
        }
    }
}
