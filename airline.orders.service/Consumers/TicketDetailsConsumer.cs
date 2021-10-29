using airline.management.abstractions.Orders;
using airline.orders.service.Events;
using airline.orders.service.Persistence.Repositories.Abstractions;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace airline.orders.service.Consumers
{
    public class TicketDetailsConsumer : IConsumer<ITicketDetailRequestEvent>
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketDetailsConsumer(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task Consume(ConsumeContext<ITicketDetailRequestEvent> context)
        {
            var ticket = (await _ticketRepository.FindByConditionAsync(x => x.TicketNumber == context.Message.TicketNumber)).Single();

            await context.RespondAsync<ITicketDetailEvent>(new TicketDetailEvent 
            { 
                ArrivalAirport = ticket.ArrivalAirport,
                ArrivalCountry = ticket.ArrivalCountry,
                ArrivalDate = ticket.ArrivalDate,
                CorrelationId = ticket.CorrelationId,
                DepartureAirport = ticket.DepartureAirport,
                DepartureCountry = ticket.DepartureCountry,
                DepartureDate = ticket.DepartureDate,
                FlightNumber = ticket.FlightNumber            
            });
        }
    }
}
