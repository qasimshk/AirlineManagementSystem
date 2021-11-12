using airline.management.abstractions.API;
using airline.management.domain.Events;
using airline.orchestrator.service.Entities;
using airline.orchestrator.service.WorkFlow;
using FluentAssertions;
using MassTransit;
using MassTransit.Testing;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace airline.orchestrator.service.test.WorkFlow
{
    public class ServiceStateMachineTests
    {
        [Fact]
        public async Task Should_test_the_state_machine_saga()
        {
            // Arrange
            var machine = new ServiceStateMachine();

            var harness = new InMemoryTestHarness();

            var sagaHarness = harness.StateMachineSaga<ServiceTransactions, ServiceStateMachine>(machine);
            
            Guid correlationId = NewId.NextGuid();

            await harness.Start();
            try
            {
                // Act
                await harness.Bus.Publish<IOrderSubmitEvent>(new OrderSubmitEvent
                { 
                    CorrelationId = correlationId,
                    CreatedOn = DateTime.Now,
                    
                    Customer = new CustomerDetailsdsfsdfEvent
                    {
                        CorrelationId = correlationId,
                        EmailAddress = "abc@test.com",
                        FirstName = "Tom",
                        LastName = "Jerry"
                    },
                    Ticket = new CreateFlightTicketEvent
                    {
                        ArrivalAirport = "Jinnah Terminal",
                        ArrivalCountry = "Pakistan",
                        ArrivalDate = DateTime.Parse("2021-11-06"),
                        CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                        DepartureAirport = "Heathrow International",
                        DepartureCountry = "England",
                        DepartureDate = DateTime.Parse("2021-11-05"),
                        FlightNumber = "123456"
                    },
                    TicketPrice = 12.00
                });

                // Assert
                // did the endpoint consume the message
                harness.Consumed.Select<IOrderSubmitEvent>().Any().Should().BeTrue();

                // did the actual consumer [state machine] consume the message
                sagaHarness.Consumed.Select<IOrderSubmitEvent>().Any().Should().BeTrue();
                
                var instance = sagaHarness.Created.ContainsInState(correlationId, machine, machine.Submitted);

                instance.Should().NotBeNull();

                instance.CurrentState.Should().BeEquivalentTo("Submitted");               
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}
