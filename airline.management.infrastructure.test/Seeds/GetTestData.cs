using airline.customers.service.Entities;
using airline.management.application.Models;
using System;
using System.Collections.Generic;

namespace airline.management.infrastructure.test.Seeds
{
    public static class GetTestData
    {
        public static List<CountryDetailsDto> GetMockedCountriesData()
        {
            return new()
            { 
                new CountryDetailsDto
                {
                    CountryCode = "GBR",
                    CountryName = "United Kingdom"
                },
                new CountryDetailsDto
                {
                    CountryCode = "USA",
                    CountryName = "United States of America"
                },
                new CountryDetailsDto
                {
                    CountryCode = "AUS",
                    CountryName = "Australia"
                }
            };
        }

        public static List<FlightDetailsDto> GetMockedFlightDetailsData()
        {
            return new()
            {
                new FlightDetailsDto
                {
                    DepartureAirport = "Heathrow",
                    DepartureCountry = "England",
                    ArrivalAirport = "Jinnah Terminal",
                    ArrivalCountry = "Pakistan",
                    CruiseSpeed = 1234,
                    Distance = 1234,
                    FlightNo = "FT1234",
                    ManufacturerName = "AirBus",
                    ModelNumber = "1234",
                    PlaneRange = 1234
                }
            };
        }

        public static List<Customers> GetMockCustomerDetailEvent()
        {
            return new() 
            {
                new Customers
                {
                    CorrelationId = Guid.Parse("06d53a96-7973-450b-9e72-451ec35d977e"),
                    EmailAddress = "tom@abc.com",
                    FirstName = "Tom",
                    LastName = "Jerry",
                    CustomerRef = Guid.Parse("06d53a96-7973-450b-9e72-451ec35d977e")
                }
            };
        }
    }
}
