using airline.management.abstractions.API;
using airline.management.abstractions.Orders;
using airline.management.application.Abstractions.Services;
using airline.management.domain.Events;
using airline.management.domain.Exceptions;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Services
{
    public class OrchestratorService : IOrchestratorService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private IRequestClient<IOrderStateRequestEvent> _orderStateRequest;
        
        public OrchestratorService(IPublishEndpoint publishEndpoint, IRequestClient<IOrderStateRequestEvent> orderStateRequest)
        {
            _publishEndpoint = publishEndpoint;
            _orderStateRequest = orderStateRequest;
        
        }

        public async Task SubmitOrder(OrderSubmitEvent orderSubmitEvent, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderSubmitEvent>(orderSubmitEvent, cancellationToken);
        }

        public async Task<OrderStateEvent> GetOrderState(Guid orderNumber, CancellationToken cancellationToken)
        {
            var response = await _orderStateRequest.GetResponse<IOrderStateEvent>(new OrderStateRequestEvent
            {
                CorrelationId = orderNumber
            }, cancellationToken);

            if (response == null) throw new NotFoundException("Invalid order number");

            return new OrderStateEvent
            {
                CorrelationId = response.Message.CorrelationId,
                CreatedOn = response.Message.CreatedOn,
                CurrentState = response.Message.CurrentState,
                CustomerId = response.Message.CustomerId,
                OrderId = response.Message.OrderId,
                PaymentId = response.Message.PaymentId,
                TicketNumber = response.Message.TicketNumber,
                TicketPrice = response.Message.TicketPrice
            };
        }
    }
}
