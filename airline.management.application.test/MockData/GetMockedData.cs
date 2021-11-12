using airline.management.application.Commands.SubmitOrder;
using airline.management.application.Models;
using airline.management.domain.Events;
using System;
using System.Collections.Generic;

namespace airline.management.application.test.MockData
{
    public static class GetMockedData
    {
        public static SubmitOrderCommand GetSubmitOrderCommand()
        {
            return new SubmitOrderCommand
            {
                DepartureDate = DateTime.Parse("2021-11-05"),
                EmailAddress = "testemail@abc.com",
                FirstName = "Tom",
                LastName = "Jerry",
                FlightNumber = "12345"               
            };
        }

        public static OrderSubmittedDto GetOrderSubmittedDto()
        {
            return new OrderSubmittedDto
            {
                Customer = "Tom Jerry",
                EmailAddress = "testemail@abc.com",
                OrderDate = "2021-11-05",
                OrderNumber = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
            };
        }

        public static OrderSubmittedEvent GetOrderSubmitEvent()
        {
            return new OrderSubmittedEvent
            { 
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                Customer = "Tom Jerry",
                EmailAddress = "testemail@abc.com",
                OrderDate = "2021-11-05",
            };
        }

        public static CreateFlightTicketEvent GetCreateFlightTicketEvent()
        {
            return new CreateFlightTicketEvent
            {
                ArrivalAirport = "Jinnah Terminal",
                ArrivalCountry = "Pakistan",
                ArrivalDate = DateTime.Parse("2021-11-06"),
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                DepartureAirport = "Heathrow International",
                DepartureCountry = "England",
                DepartureDate = DateTime.Parse("2021-11-05"),
                FlightNumber = "123456"
            };
        }

        public static FlightDetailsDto GetFlightDetailsDto()
        {
            return new FlightDetailsDto 
            {
                ArrivalAirport = "Jinnah Terminal",
                ArrivalCountry = "Pakistan",                                
                DepartureAirport = "Heathrow International",
                DepartureCountry = "England",
                CruiseSpeed = 1234,
                Distance = 1234,
                FlightNo = "1234",
                ManufacturerName = "AirBus",
                ModelNumber = "A380",
                PlaneRange = 12345                
            };
        }

        public static OrderStateEvent GetOrderStateEvent()
        {
            return new OrderStateEvent
            { 
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                CreatedOn = DateTime.Parse("2021-11-05").ToString(),
                CurrentState = "Complete",
                CustomerId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716").ToString(),
                OrderId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716").ToString(),
                PaymentId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716").ToString(),
                TicketNumber = "12345",
                TicketPrice = "50.00£"
            };
        }

        public static List<FlightDetailsDto> GetListOfFlightDetailsDto()
        {
            return new List<FlightDetailsDto> 
            {
                new FlightDetailsDto
                {
                    ArrivalAirport = "Jinnah Terminal",
                    ArrivalCountry = "Pakistan",
                    DepartureAirport = "Heathrow International",
                    DepartureCountry = "England",
                    CruiseSpeed = 1234,
                    Distance = 1234,
                    FlightNo = "1234",
                    ManufacturerName = "AirBus",
                    ModelNumber = "A380",
                    PlaneRange = 12345
                }
            };
        }

        public static CustomerTicketDto GetCustomerTicketDto()
        {
            return new CustomerTicketDto
            {
                Arrival = new FlightDetails
                {
                    Airport = "Jinnah Terminal",
                    Country = "Pakistan",
                    FlightgDate = DateTime.Now.AddDays(1).ToString("d")
                },
                Departure = new FlightDetails
                {
                    Airport = "Heathrow International",
                    Country = "England",
                    FlightgDate = DateTime.Now.ToString("d")
                },
                FlightNumber = "123456",
                FullName = "Tom Jerry",
                TicketAmount = "£50.00",
                TicketNumber = "FL12345"
            };
        }

        public static CustomerDetailsEvent GetCustomerDetailsEvent()
        {
            return new CustomerDetailsEvent
            {
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                EmailAddress = "tom@abc.com",
                FirstName = "Tom",
                LastName = "Jerry"
            };
        }

        public static TicketPaymentDetailsEvent GetTicketPaymentDetailsEvent()
        {
            return new TicketPaymentDetailsEvent
            {
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                Amount = 50.00
            };
        }

        public static TicketDetailEvent GetTicketDetailEvent()
        {
            return new TicketDetailEvent
            {
                ArrivalAirport = "Jinnah Terminal",
                ArrivalCountry = "Pakistan",
                DepartureAirport = "Heathrow International",
                DepartureCountry = "England",
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartureDate = DateTime.Now,
                CorrelationId = Guid.Parse("593bc330-fac8-439f-8b0a-d728e7197716"),
                FlightNumber = "123456"
            };
        }
    }
}
