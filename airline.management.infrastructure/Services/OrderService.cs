using airline.management.abstractions.Orders;
using airline.management.application.Abstractions.Services;
using airline.management.domain.Events;
using MassTransit;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRequestClient<ITicketDetailRequestEvent> _requestClient;

        public OrderService(IRequestClient<ITicketDetailRequestEvent> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<TicketDetailEvent> GetTicketDetails(string ticketNumber, CancellationToken cancellationToken)
        {
            var response = await _requestClient.GetResponse<ITicketDetailEvent>(new TicketDetailRequestEvent
            {                
                TicketNumber = ticketNumber
            }, cancellationToken);

            return new TicketDetailEvent
            {
                ArrivalAirport = response.Message.ArrivalAirport,
                ArrivalCountry = response.Message.ArrivalCountry,
                ArrivalDate = response.Message.ArrivalDate,
                CorrelationId = response.Message.CorrelationId,
                DepartureAirport = response.Message.DepartureAirport,
                DepartureCountry = response.Message.DepartureCountry,
                DepartureDate = response.Message.DepartureDate,
                FlightNumber = response.Message.FlightNumber
            };
        }
    }
}
