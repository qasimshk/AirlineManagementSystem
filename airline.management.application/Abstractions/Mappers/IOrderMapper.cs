using airline.management.application.Commands.SubmitOrder;
using airline.management.application.Models;
using airline.management.domain.Events;
using airline.management.sharedkernal.Abstractions;

namespace airline.management.application.Abstractions.Mappers
{
    public interface IOrderMapper : 
        IMapper<OrderSubmitEvent, OrderSubmittedDto>, 
        IMapper<SubmitOrderCommand, OrderSubmitEvent>, 
        IMapper<OrderStateEvent, OrderStateDto>
    { }
}
