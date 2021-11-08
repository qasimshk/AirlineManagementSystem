using airline.management.abstractions.Failed;
using airline.management.abstractions.Orders;
using airline.orders.service.Consumers;
using airline.orders.service.Entities;
using airline.orders.service.Persistence.Repositories.Abstractions;
using FluentAssertions;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace airline.orders.service.test.Consumers
{
    public class TicketConsumeTests
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketConsumeTests()
        {
            _ticketRepository = Substitute.For<ITicketRepository>();
        }

        [Fact]
        public async Task TicketConsumer_ShouldReturnOrderDetails_ReturnSuccessful()
        {
            // Arrange
            var tickets = GetMockData.GetMockTicketDetails();

            var provider = new ServiceCollection()
            .AddMassTransitInMemoryTestHarness(cfg =>
            {
                cfg.AddConsumer<TicketConsumer>();
                cfg.AddConsumerTestHarness<TicketConsumer>();
            })
            .AddScoped(x => _ticketRepository)
            .BuildServiceProvider(true);

            _ticketRepository.FindByConditionAsync(Arg.Any<Expression<Func<Tickets, bool>>>()).Returns(tickets);

            var harness = provider.GetRequiredService<InMemoryTestHarness>();

            await harness.Start();
            try
            {
                // Act
                var bus = provider.GetRequiredService<IBus>();

                var client = bus.CreateRequestClient<ICreateFlightTicketEvent>();

                var response = await client.GetResponse<ITicketCreatedSuccessfullyEvent>(new TicketCreatedSuccessfullyEvent
                {
                    CorrelationId = tickets.Single().CorrelationId,
                    OrderId = tickets.Single().OrderRef,
                    TicketNumber = tickets.Single().TicketNumber
                });

                var result = await harness.Consumed.Any<ICreateFlightTicketEvent>();

                // Assert
                result.Should().BeTrue();

                var consumerHarness = provider.GetRequiredService<IConsumerTestHarness<TicketConsumer>>();

                (await consumerHarness.Consumed.Any<ICreateFlightTicketEvent>()).Should().BeTrue();

                (await consumerHarness.Consumed.Any<IFailedEvent>()).Should().BeFalse();

                response.Message.TicketNumber.Should().BeEquivalentTo(tickets.Single().TicketNumber);
            }
            finally
            {
                await harness.Stop();

                await provider.DisposeAsync();
            }
        }
    }

    public class TicketCreatedSuccessfullyEvent : ITicketCreatedSuccessfullyEvent
    {
        public Guid OrderId { get; set; }
        public string TicketNumber { get; set; }
        public Guid CorrelationId { get; set; }
    }

    public static class GetMockData
    {
        public static List<Tickets> GetMockTicketDetails()
        {
            return new List<Tickets>
            {
                new Tickets
                {
                    ArrivalAirport = "Jinnah Terminal",
                    ArrivalCountry = "Pakistan",
                    ArrivalDate = DateTime.Parse("2021-11-06"),
                    CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                    DepartureAirport = "Heathrow International",
                    DepartureCountry = "England",
                    DepartureDate = DateTime.Parse("2021-11-05"),
                    FlightNumber = "123456",
                    OrderRef = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                    TicketNumber = "123456"
                }
            };
        }
    }
}
