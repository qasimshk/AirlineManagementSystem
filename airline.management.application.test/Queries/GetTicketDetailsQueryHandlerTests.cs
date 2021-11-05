using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using airline.management.application.Queries.GetTicketDetails;
using airline.management.application.test.MockData;
using FluentAssertions;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.application.test.Queries
{
    public class GetTicketDetailsQueryHandlerTests
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IOrchestratorService _orchestratorService;
        private readonly GetTicketDetailsQueryHandler _sut;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public GetTicketDetailsQueryHandlerTests()
        {
            _customerService = Substitute.For<ICustomerService>();
            _orchestratorService = Substitute.For<IOrchestratorService>();
            _orderService = Substitute.For<IOrderService>();
            _paymentService = Substitute.For<IPaymentService>();
            _cancellationTokenSource = new CancellationTokenSource();
            _sut = new GetTicketDetailsQueryHandler(_customerService, _orderService, _paymentService, _orchestratorService);
        }

        [Fact]
        public async Task Handle_ShouldReturnCustomerTicketDto_ReturnSuccessful()
        {
            // Arrange
            var query = new GetTicketDetailsQuery("FL12345");
            var response = GetMockedData.GetCustomerTicketDto();

            _orderService.GetTicketDetails(Arg.Any<string>(), _cancellationTokenSource.Token).Returns(GetMockedData.GetTicketDetailEvent());
            _customerService.GetCustomerDetails(Arg.Any<Guid>(), _cancellationTokenSource.Token).Returns(GetMockedData.GetCustomerDetailsEvent());
            _orchestratorService.GetOrderState(Arg.Any<Guid>(), _cancellationTokenSource.Token).Returns(GetMockedData.GetOrderStateEvent());            
            _paymentService.GetTicketPaymentDetails(Arg.Any<Guid>(), _cancellationTokenSource.Token).Returns(GetMockedData.GetTicketPaymentDetailsEvent());

            // Act
            var result = await _sut.Handle(query, _cancellationTokenSource.Token);

            // Assert
            result.Should().BeOfType<CustomerTicketDto>();

            result.Should().BeEquivalentTo(response);
        }
    }
}
