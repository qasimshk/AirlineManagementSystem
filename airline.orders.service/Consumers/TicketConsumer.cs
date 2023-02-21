using airline.management.abstractions.Failed;
using airline.management.abstractions.Orders;
using airline.orders.service.Entities;
using airline.orders.service.Events;
using airline.orders.service.Persistence.Repositories.Abstractions;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace airline.orders.service.Consumers
{
    public class TicketConsumer : IConsumer<ICreateFlightTicketEvent>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ILogger<TicketConsumer> _logger;

        public TicketConsumer(ITicketRepository ticketRepository, ILogger<TicketConsumer> logger)
        {
            _ticketRepository = ticketRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ICreateFlightTicketEvent> context)
        {
            try
            {
                _logger.LogInformation("Ticket details received");
                
                var entity = new Tickets
                {
                    ArrivalAirport = context.Message.ArrivalAirport,
                    ArrivalCountry = context.Message.ArrivalCountry,
                    ArrivalDate = context.Message.ArrivalDate,
                    CorrelationId = context.Message.CorrelationId,
                    DepartureAirport = context.Message.DepartureAirport,
                    DepartureCountry = context.Message.DepartureCountry,
                    DepartureDate = context.Message.DepartureDate,
                    FlightNumber = context.Message.FlightNumber,
                    OrderRef = Guid.NewGuid(),
                    TicketNumber = string.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000)
                };

                _ticketRepository.Add(entity);

                await _ticketRepository.UnitOfWork.SaveEntitiesAsync();

                _logger.LogInformation("Ticket created received");                

                var ticket = await _ticketRepository.FindByConditionAsync(x => x.CorrelationId == context.Message.CorrelationId);

                await context.RespondAsync<ITicketCreatedSuccessfullyEvent>(new TicketCreatedSuccessfullyEvent
                {
                    OrderId = ticket.Single().OrderRef,
                    TicketNumber = ticket.Single().TicketNumber,
                    CorrelationId = context.Message.CorrelationId
                });
            }
            catch(Exception ex)
            {
                _logger.LogError("Service was not able to create ticket");
                
                await context.RespondAsync<IFailedEvent>(new FailedEvent
                {
                    ConsumerName = nameof(TicketConsumer),
                    ErrorMessage = ex.ToString(),
                    CorrelationId = context.Message.CorrelationId
                });
            }
        }
    }
}
