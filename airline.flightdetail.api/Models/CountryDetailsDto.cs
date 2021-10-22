using Newtonsoft.Json;

namespace airline.flightdetail.api.Models
{
    public class CountryDetailsDto
    {
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "ISO")]
        public string CountryCode { get; set; }
    }
}
