using airline.management.application.Abstractions.Mappers;
using airline.management.application.Abstractions.Services;
using airline.management.application.Commands.SubmitOrder;
using airline.management.application.test.MockData;
using airline.management.domain.Events;
using FluentAssertions;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.application.test.Commands
{
    public class SubmitOrderCommandHandlerTests
    {
        private readonly IOrchestratorService _orchestratorService;
        private readonly IOrderMapper _orderMapper;
        private readonly SubmitOrderCommandHandler _sut;

        public SubmitOrderCommandHandlerTests()
        {
            _orchestratorService = Substitute.For<IOrchestratorService>();
            _orderMapper = Substitute.For<IOrderMapper>();
            _sut = new SubmitOrderCommandHandler(_orchestratorService, _orderMapper);
        }

        [Fact]
        public async Task Handle_ShouldReturnSubmitOrderSuccessfully_ReturnSuccessful()
        {
            // Arrange
            var request = GetMockedData.GetSubmitOrderCommand();
            var cancellationTokenSource = new CancellationTokenSource();

            //_orderMapper.Map(Arg.Any<SubmitOrderCommand>()).Returns(GetMockedData.GetOrderSubmitEvent());
            _orderMapper.Map(Arg.Any<OrderSubmittedEvent>()).Returns(GetMockedData.GetOrderSubmittedDto());

            // Act
            var result = await _sut.Handle(request, cancellationTokenSource.Token);

            // Assert
            result.Should().NotBeNull();

            result.EmailAddress.Should().BeEquivalentTo(request.EmailAddress);
        }
    }
}
