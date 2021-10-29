namespace airline.management.infrastructure.Url
{
    public static class FlightDetailOperations
    {
        public static string GetAllCountries() => "Country/All";
        public static string GetAllAvailableFlights() => "Booking/AvailableFlights";
        public static string GetAvailableFlightByDestination(string destination, string arrival) => $"Booking/Search/{destination}/To/{arrival}";
        public static string GetAvailableFlightByFlightNumber(string flightNumber) => $"Booking/SearchFlight/{flightNumber}";
    }
}
