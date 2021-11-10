namespace airline.management.infrastructure.BusinessProcess
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
