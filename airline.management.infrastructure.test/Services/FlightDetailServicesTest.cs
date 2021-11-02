using airline.management.application.Abstractions.Services;
using airline.management.application.Models;
using airline.management.infrastructure.Services;
using airline.management.infrastructure.test.Seeds;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace airline.management.infrastructure.test.Services
{
    public class FlightDetailServicesTest
    {
        private IFlightDetailServices _sut;

        [Fact]
        public async Task GetAllCountry_ShouldReturnCountries_ReturnSuccessful()
        {
            // Arrange 
            var mockCountries = GetTestData.GetMockedCountriesData();
            var httpClient = MockHttpClientResponse.SetHttpClientResponse(mockCountries, HttpStatusCode.OK);
            
            _sut = new FlightDetailServices(httpClient);

            // Act
            var result = await _sut.GetAllCountry();

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<List<CountryDetailsDto>>();

            result.First().CountryName.Should().BeEquivalentTo(mockCountries.First().CountryName);
        }

        [Fact]
        public async Task GetAvailableFlights_ShouldReturnAvailableFlights_ReturnSuccessful()
        {
            // Arrange 
            var mockFlightDetails = GetTestData.GetMockedFlightDetailsData();
            var httpClient = MockHttpClientResponse.SetHttpClientResponse(mockFlightDetails, HttpStatusCode.OK);

            _sut = new FlightDetailServices(httpClient);

            // Act
            var result = await _sut.GetAvailableFlights();

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<List<FlightDetailsDto>>();

            result.First().DepartureAirport.Should().BeEquivalentTo(mockFlightDetails.First().DepartureAirport);

            result.First().ArrivalAirport.Should().BeEquivalentTo(mockFlightDetails.First().ArrivalAirport);
        }

        [Fact]
        public async Task GetFlightByDestination_ShouldReturnFlightsByDestination_ReturnSuccessful()
        {
            // Arrange 
            var mockFlightDetails = GetTestData.GetMockedFlightDetailsData();
            var httpClient = MockHttpClientResponse.SetHttpClientResponse(mockFlightDetails, HttpStatusCode.OK);

            _sut = new FlightDetailServices(httpClient);

            // Act
            var result = await _sut.GetFlightByDestination("GBR", "USA");

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<List<FlightDetailsDto>>();

            result.First().DepartureAirport.Should().BeEquivalentTo(mockFlightDetails.First().DepartureAirport);

            result.First().ArrivalAirport.Should().BeEquivalentTo(mockFlightDetails.First().ArrivalAirport);
        }

        [Fact]
        public async Task GetFlightByFlightNumber_ShouldReturnFlightsByNumber_ReturnSuccessful()
        {
            // Arrange 
            var mockFlightDetails = GetTestData.GetMockedFlightDetailsData().First();
            var httpClient = MockHttpClientResponse.SetHttpClientResponse(mockFlightDetails, HttpStatusCode.OK);

            _sut = new FlightDetailServices(httpClient);

            // Act
            var result = await _sut.GetFlightByFlightNumber("123456789");

            // Assert
            result.Should().NotBeNull();

            result.Should().BeOfType<FlightDetailsDto>();

            result.DepartureAirport.Should().BeEquivalentTo(mockFlightDetails.DepartureAirport);

            result.ArrivalAirport.Should().BeEquivalentTo(mockFlightDetails.ArrivalAirport);
        }
    }
}
