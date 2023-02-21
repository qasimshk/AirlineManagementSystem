using airline.management.abstractions.Failed;
using airline.management.abstractions.Payments;
using airline.payment.service.Entities;
using airline.payment.service.Events;
using airline.payment.service.Persistence.Repositories.Abstractions;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace airline.payment.service.Consumers
{
    public class PaymentConsumer : IConsumer<IAddPaymentEvent>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<PaymentConsumer> _logger;

        public PaymentConsumer(ITransactionRepository transactionRepository, ILogger<PaymentConsumer> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IAddPaymentEvent> context)
        {
            try
            {
                _logger.LogInformation("Payment event received");
                
                var entity = new Transactions                 
                { 
                    Amount = context.Message.Amount,
                    CorrelationId = context.Message.CorrelationId,
                    OrderId = context.Message.OrderId,
                    TransactionRef = Guid.NewGuid()
                };

                _transactionRepository.Add(entity);

                await _transactionRepository.UnitOfWork.SaveEntitiesAsync();

                _logger.LogInformation("Payment record processed successfully");
                
                var transaction = await _transactionRepository.FindByConditionAsync(x => x.OrderId == context.Message.OrderId);

                await context.RespondAsync<IPaymentProcessedSuccessfullyEvent>(new PaymentProcessedSuccessfully
                {
                    CorrelationId = context.Message.CorrelationId,
                    PaymentId = transaction.Single().TransactionRef
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Service was not able to save Payment details");
                
                await context.RespondAsync<IFailedEvent>(new FailedEvent
                {
                    ConsumerName = nameof(PaymentConsumer),
                    ErrorMessage = ex.ToString(),
                    CorrelationId = context.Message.CorrelationId
                });
            }
        }
    }
}
