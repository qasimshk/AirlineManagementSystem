using airline.management.application.Abstractions.Mappers;
using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Commands.SubmitOrder
{
    public class SubmitOrderCommandHandler : IRequestHandler<SubmitOrderCommand, OrderSubmittedDto>
    {
        private readonly IOrchestratorService _orchestratorService;
        private readonly IOrderMapper _orderMapper;
        
        public SubmitOrderCommandHandler(IOrchestratorService orchestratorService, IOrderMapper orderMapper)
        {
            _orchestratorService = orchestratorService;
            _orderMapper = orderMapper;        
        }

        public async Task<OrderSubmittedDto> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {
            var service = _orderMapper.Map(request);

            await _orchestratorService.SubmitOrder(service, cancellationToken);

            return _orderMapper.Map(service);
        }        
    }
}
