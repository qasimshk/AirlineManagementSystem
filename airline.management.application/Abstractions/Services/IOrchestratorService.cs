using airline.management.domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Abstractions.Services
{
    public interface IOrchestratorService
    {
        Task<OrderSubmittedEvent> SubmitOrder(OrderSubmitEvent orderSubmitEvent, CancellationToken cancellationToken);
        Task<OrderStateEvent> GetOrderState(Guid OrderNumber, CancellationToken cancellationToken);
    }
}
