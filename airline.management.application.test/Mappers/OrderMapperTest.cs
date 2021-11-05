using airline.management.application.Abstractions.Services;
using airline.management.application.Mappers;
using airline.management.application.Models;
using airline.management.application.test.MockData;
using airline.management.domain.Events;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace airline.management.application.test.Mappers
{
    public class OrderMapperTest 
    {
        private readonly IFlightDetailServices _flightDetailServices;
        private readonly OrderMapper _sut;

        public OrderMapperTest()
        {
            _flightDetailServices = Substitute.For<IFlightDetailServices>();
            _sut = new OrderMapper(_flightDetailServices);
        }

        [Fact]
        public void OrderSubmitEventMap_ShouldReturnOrderSubmittedDto_ReturnSuccessful()
        {
            // Arrange
            var orderSubmit = GetMockedData.GetOrderSubmitEvent();

            // Act
            var result = _sut.Map(orderSubmit);

            // Assert
            result.Should().BeOfType<OrderSubmittedDto>();

            result.Should().BeEquivalentTo(GetMockedData.GetOrderSubmittedDto());
        }

        [Fact]
        public void SubmitOrderCommandMap_ShouldReturnOrderSubmitEvent_ReturnSuccessful()
        {
            // Arrange
            var command = GetMockedData.GetSubmitOrderCommand();

            _flightDetailServices.GetFlightByFlightNumber(Arg.Any<string>()).Returns(GetMockedData.GetFlightDetailsDto());

            // Act
            var result = _sut.Map(command);

            // Assert
            result.Should().BeOfType<OrderSubmitEvent>();

            result.Customer.EmailAddress.Should().BeEquivalentTo(command.EmailAddress);
        }

        [Fact]
        public void OrderStateEventMap_ShouldReturnOrderStateDto_ReturnSuccessful()
        {
            // Arrange
            var events = GetMockedData.GetOrderStateEvent();

            // Act
            var result = _sut.Map(events);

            // Assert
            result.Should().BeOfType<OrderStateDto>();

            result.TicketNumber.Should().BeEquivalentTo(events.TicketNumber);

            result.TicketPrice.Should().BeEquivalentTo(events.TicketPrice);
        }
    }
}
