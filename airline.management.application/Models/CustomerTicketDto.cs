namespace airline.management.application.Models
{
    public class CustomerTicketDto
    {
        public string FullName { get; set; }
        public string FlightNumber { get; set; }
        public string TicketNumber { get; set; }
        public FlightDetails Departure { get; set; }
        public FlightDetails Arrival { get; set; }
    }

    public class FlightDetails
    {
        public string Airport { get; set; }
        public string Country { get; set; }
        public string FlightgDate { get; set; }        
    }
}
