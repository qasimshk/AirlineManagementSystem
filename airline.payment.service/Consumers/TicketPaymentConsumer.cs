using airline.management.abstractions.Payments;
using airline.payment.service.Events;
using airline.payment.service.Persistence.Repositories.Abstractions;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace airline.payment.service.Consumers
{
    public class TicketPaymentConsumer : IConsumer<ITicketPaymentDetailsRequestEvent>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TicketPaymentConsumer(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Consume(ConsumeContext<ITicketPaymentDetailsRequestEvent> context)
        {
            var transaction = (await _transactionRepository.FindByConditionAsync(x => x.TransactionRef == context.Message.PaymentReference)).SingleOrDefault();

            await context.RespondAsync<ITicketPaymentDetailsEvent>(new TicketPaymentDetails
            {
                CorrelationId = transaction.CorrelationId,
                Amount = transaction.Amount
            });
        }
    }
}
