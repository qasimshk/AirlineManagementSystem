using airline.management.application.Models;
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
    }
}
