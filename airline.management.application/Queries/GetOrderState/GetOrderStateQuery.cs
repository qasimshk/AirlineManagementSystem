using airline.management.application.Models;
using MediatR;
using System;

namespace airline.management.application.Queries.GetOrderState
{
    public class GetOrderStateQuery : IRequest<OrderStateDto>
    {
        public GetOrderStateQuery(string orderNumber)
        {
            OrderNumber = Guid.Parse(orderNumber);
        }

        public Guid OrderNumber { get; init; }
    }
}
