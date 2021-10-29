using airline.management.application.Models;
using MediatR;

namespace airline.management.application.Queries.GetTicketDetails
{
    public class GetTicketDetailsQuery : IRequest<CustomerTicketDto>
    {
        public GetTicketDetailsQuery(string ticketNumber, string orderNumber)
        {
            TicketNumber = ticketNumber;
            OrderNumber = orderNumber;
        }

        public string TicketNumber { get; init; }
        public string OrderNumber { get; init; }
    }
}
