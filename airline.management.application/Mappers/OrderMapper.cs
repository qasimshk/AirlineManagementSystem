using airline.management.application.Abstractions.Mappers;
using airline.management.application.Abstractions.Services;
using airline.management.application.Commands.SubmitOrder;
using airline.management.application.Models;
using airline.management.domain.Events;
using airline.management.domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace airline.management.application.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        private readonly IFlightDetailServices _flightDetailServices;

        public OrderMapper(IFlightDetailServices flightDetailServices)
        {
            _flightDetailServices = flightDetailServices;
        }

        public OrderSubmittedDto Map(OrderSubmitEvent from)
        {
            return new OrderSubmittedDto
            {
                Customer = $"{from.Customer.FirstName} {from.Customer.LastName}",
                EmailAddress = from.Customer.EmailAddress,
                OrderNumber = from.CorrelationId,
                OrderDate = from.CreatedOn.ToString("dd/MM/yyyy")
            };
        }

        public OrderSubmitEvent Map(SubmitOrderCommand from)
        {
            var correlationId = Guid.NewGuid();
            var ticket = GetFlightDetailsByFlightNumber(from.FlightNumber, from.DepartureDate, correlationId).Result;

            return new OrderSubmitEvent
            {
                CorrelationId = correlationId,
                CreatedOn = DateTime.Now,
                Customer = new CustomerDetailsdsfsdfEvent
                {
                    CorrelationId = correlationId,
                    EmailAddress = from.EmailAddress,
                    FirstName = from.FirstName,
                    LastName = from.LastName
                },
                Ticket = ticket,
                TicketPrice = TicketAmount()
            };
        }

        private double TicketAmount()
        {
            var price = new Random();
            return price.Next(11, 99);
        }

        private async Task<CreateFlightTicketEvent> GetFlightDetailsByFlightNumber(string flightNumber, DateTime departureDate, Guid correlationId)
        {
            var details = await _flightDetailServices.GetFlightByFlightNumber(flightNumber);

            if (details == null) throw new NotFoundException("Invalid flight number");

            return new CreateFlightTicketEvent
            {
                CorrelationId = correlationId,
                ArrivalAirport = details.ArrivalAirport,
                ArrivalCountry = details.ArrivalCountry,
                ArrivalDate = departureDate.AddDays(1),
                DepartureAirport = details.DepartureAirport,
                DepartureCountry = details.DepartureCountry,
                DepartureDate = departureDate,
                FlightNumber = details.FlightNo
            };
        }

        public OrderStateDto Map(OrderStateEvent from)
        {
            return new OrderStateDto
            {
                BookingDate = from.CreatedOn,
                CustomerReference = from.CustomerId,
                OrderNumber = from.CorrelationId,
                OrderReference = from.OrderId,
                OrderState = from.CurrentState,
                PaymentReference = from.PaymentId,
                TicketNumber = from.TicketNumber,
                TicketPrice = from.TicketPrice
            };
        }
    }
}
