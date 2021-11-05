using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using airline.management.application.Queries.GetFlightByDestination;
using airline.management.application.test.MockData;
using airline.management.domain.Exceptions;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.application.test.Queries
{
    public class GetFlightByDestinationQueryHandlerTests
    {
        private readonly IFlightDetailServices _flightDetailServices;
        private readonly GetFlightByDestinationQueryHandler _sut;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public GetFlightByDestinationQueryHandlerTests()
        {
            _flightDetailServices = Substitute.For<IFlightDetailServices>();
            _sut = new GetFlightByDestinationQueryHandler(_flightDetailServices);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        [Fact]
        public async Task Handle_ShouldReturnListFlightDetailsDto_ReturnSuccessful()
        {
            // Arrange
            var query = new GetFlightByDestinationQuery("eng","pak");
            var response = GetMockedData.GetListOfFlightDetailsDto();

            _flightDetailServices.GetFlightByDestination(query.Departure, query.Arrival).Returns(response);

            // Act
            var result = await _sut.Handle(query, _cancellationTokenSource.Token);

            // Assert
            result.Should().BeOfType<List<FlightDetailsDto>>();

            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void Handle_ShouldReturnNotFound_ReturnException()
        {
            // Arrange
            var query = new GetFlightByDestinationQuery("eng", "pak");
            var response = GetMockedData.GetListOfFlightDetailsDto();

            // Act
            var ex = Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(query, _cancellationTokenSource.Token)).Result;

            // Assert
            Assert.Equal("No flight found with provided destination", ex.Message);
        }
    }
}
