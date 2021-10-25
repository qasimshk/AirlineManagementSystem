using Newtonsoft.Json;

namespace airline.management.application.Models
{
    public class CountryDetailsDto
    {
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "ISO")]
        public string CountryCode { get; set; }
    }
}
