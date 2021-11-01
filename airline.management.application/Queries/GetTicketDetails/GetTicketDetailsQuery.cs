using airline.management.application.Models;
using MediatR;

namespace airline.management.application.Queries.GetTicketDetails
{
    public class GetTicketDetailsQuery : IRequest<CustomerTicketDto>
    {
        public GetTicketDetailsQuery(string ticketNumber)
        {
            TicketNumber = ticketNumber;            
        }

        public string TicketNumber { get; init; }        
    }
}
