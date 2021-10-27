using airline.customers.service.Events;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Failed;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace airline.customers.service.Consumers
{
    public class CustomerConsumer : IConsumer<ICreateOrUpdateCustomerEvent>
    {
        public CustomerConsumer()
        {

        }

        public async Task Consume(ConsumeContext<ICreateOrUpdateCustomerEvent> context)
        {
            try
            {
                Console.WriteLine("--> Customer event received");

                //TODO:

                Console.WriteLine("--> Customer record processed successfully");

                await context.RespondAsync<ICustomerProcessedSuccessfullyEvent>(new CustomerProcessedSuccessfullyEvent
                {
                    CustomerId = Guid.NewGuid(),
                    CorrelationId = context.Message.CorrelationId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("--> Service was not able to save customer details");

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
