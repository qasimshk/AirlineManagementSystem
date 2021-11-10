using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using airline.management.domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.application.Queries.GetTicketDetails
{
    public class GetTicketDetailsQueryHandler : IRequestHandler<GetTicketDetailsQuery, CustomerTicketDto>
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IOrchestratorService _orchestratorService;

        public GetTicketDetailsQueryHandler(ICustomerService customerService, IOrderService orderService, IPaymentService paymentService, IOrchestratorService orchestratorService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _paymentService = paymentService;
            _orchestratorService = orchestratorService;
        }

        public async Task<CustomerTicketDto> Handle(GetTicketDetailsQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _orderService.GetTicketDetails(request.TicketNumber, cancellationToken);

            var orderDetails = await _orchestratorService.GetOrderState(ticket.CorrelationId, cancellationToken);

            var customer = await _customerService.GetCustomerDetails(Guid.Parse(orderDetails.CustomerId), cancellationToken);

            var payment = await _paymentService.GetTicketPaymentDetails(Guid.Parse(orderDetails.PaymentId), cancellationToken);

            return Map(ticket, customer, payment, request.TicketNumber);
        }

        private CustomerTicketDto Map(TicketDetailEvent ticketDetailEvent, CustomerDetailsEvent customerDetailsEvent, TicketPaymentDetailsEvent ticketPaymentDetailsEvent, string ticketNumber)
        {
            return new CustomerTicketDto
            {
                FlightNumber = ticketDetailEvent.FlightNumber,
                TicketNumber = ticketNumber,
                FullName = $"{customerDetailsEvent.FirstName} {customerDetailsEvent.LastName}",
                Departure = new FlightDetails
                {
                    Airport = ticketDetailEvent.DepartureAirport,
                    Country = ticketDetailEvent.DepartureCountry,
                    FlightgDate = ticketDetailEvent.DepartureDate.ToString("d")
                },
                Arrival = new FlightDetails
                {
                    Airport = ticketDetailEvent.ArrivalAirport,
                    Country = ticketDetailEvent.ArrivalCountry,
                    FlightgDate = ticketDetailEvent.ArrivalDate.ToString("d")
                },
                TicketAmount = string.Format("{0}.00£", ticketPaymentDetailsEvent.Amount)
            };
        }
    }
}
