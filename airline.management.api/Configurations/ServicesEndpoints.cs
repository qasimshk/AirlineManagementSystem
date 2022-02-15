namespace airline.management.api.Configurations
{
    public class ServicesEndpoints
    {
        public string FlightDetailsURL { get; set; }
        public int RetryAttempts { get; set; }
        public int TimeOutForRetriesInSeconds { get; set; }
        public bool IgnoreSsl { get; set; }
    }
}
