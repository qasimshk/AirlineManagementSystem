using airline.management.abstractions.Payments;
using airline.management.application.Abstractions.Services;
using airline.management.domain.Events;
using airline.management.domain.Exceptions;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRequestClient<ITicketPaymentDetailsRequestEvent> _requestClient;

        public PaymentService(IRequestClient<ITicketPaymentDetailsRequestEvent> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<TicketPaymentDetailsEvent> GetTicketPaymentDetails(Guid paymentReference, CancellationToken cancellationToken)
        {
            var response = await _requestClient.GetResponse<ITicketPaymentDetailsEvent>(new TicketPaymentDetailsRequestEvent 
            { 
               PaymentReference = paymentReference
            }, cancellationToken);

            if (response == null) throw new NotFoundException("Record not found");

            return new TicketPaymentDetailsEvent
            {
                CorrelationId = response.Message.CorrelationId,
                Amount = response.Message.Amount
            };
        }
    }
}
