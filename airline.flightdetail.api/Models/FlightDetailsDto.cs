using Newtonsoft.Json;

namespace airline.flightdetail.api.Models
{
    public class FlightDetailsDto
    {        
        public string FlightNo { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureCountry { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCountry { get; set; }
        public int Distance { get; set; }

        [JsonProperty(PropertyName = "PlaneModel")]
        public string ModelNumber { get; set; }

        [JsonProperty(PropertyName = "PlaneManufacturer")]
        public string ManufacturerName { get; set; }

        public int PlaneRange { get; set; }
        public int CruiseSpeed { get; set; }
    }
}
