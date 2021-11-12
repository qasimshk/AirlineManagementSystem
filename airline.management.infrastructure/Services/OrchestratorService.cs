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
        private IRequestClient<IOrderStateRequestEvent> _orderStateRequest;
        private IRequestClient<IOrderSubmitEvent> _orderSubmitRequest;

        public OrchestratorService(IRequestClient<IOrderStateRequestEvent> orderStateRequest, IRequestClient<IOrderSubmitEvent> orderSubmitRequest)
        {     
            _orderStateRequest = orderStateRequest;
            _orderSubmitRequest = orderSubmitRequest;        
        }

        public async Task<OrderSubmittedEvent> SubmitOrder(OrderSubmitEvent orderSubmitEvent, CancellationToken cancellationToken)
        {
            var response = await _orderSubmitRequest.GetResponse<IOrderSubmittedEvent>(orderSubmitEvent, cancellationToken);

            return new OrderSubmittedEvent
            {
                CorrelationId = response.Message.CorrelationId,
                Customer = response.Message.Customer,
                EmailAddress = response.Message.EmailAddress,
                OrderDate = response.Message.OrderDate,
                Status = response.Message.Status
            };
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
