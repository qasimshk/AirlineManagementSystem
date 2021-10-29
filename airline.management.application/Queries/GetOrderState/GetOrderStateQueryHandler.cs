using airline.management.application.Abstractions.Mappers;
using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetOrderState
{
    public class GetOrderStateQueryHandler : IRequestHandler<GetOrderStateQuery, OrderStateDto>
    {
        private readonly IOrchestratorService _orchestratorService;
        private readonly IOrderMapper _orderMapper;

        public GetOrderStateQueryHandler(IOrchestratorService orchestratorService, IOrderMapper orderMapper)
        {
            _orchestratorService = orchestratorService;
            _orderMapper = orderMapper;
        }

        public async Task<OrderStateDto> Handle(GetOrderStateQuery request, CancellationToken cancellationToken)
        {
            var response = await _orchestratorService.GetOrderState(request.OrderNumber, cancellationToken);

            var mapping = _orderMapper.Map(response);

            return mapping;
        }
    }
}
