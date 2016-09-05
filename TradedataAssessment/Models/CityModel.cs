using Newtonsoft.Json;

namespace TradedataAssessment.Models
{
    public class CityModel
    {
        [JsonProperty(PropertyName = "_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}