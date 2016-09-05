using System.Collections.Generic;
using Newtonsoft.Json;

namespace TradedataAssessment.Models
{
    public class WeatherData
    {
        [JsonProperty(PropertyName = "list")]
        public List<CurrentWeatherModel> Data { get; set; }

        [JsonProperty(PropertyName = "cnt")]
        public int TotalItems { get; set; }
    }

    public class CurrentWeatherModel
    {
        [JsonProperty(PropertyName = "coord")]
        public Coord Coordinates { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<Weather> WeatherDescription { get; set; }

        [JsonProperty(PropertyName = "main")]
        public Main WeatherParameters { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public Wind WindParameters { get; set; }

        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty(PropertyName = "sys")]
        public Sys Parameters { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string CityName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int CityId { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public class Coord
    {
        public decimal Lon { get; set; }

        public decimal Lat { get; set; }
    }

    public class Main
    {
        public decimal Temp { get; set; }

        public decimal Pressure { get; set; }

        public decimal Humidity { get; set; }

        public decimal Temp_min { get; set; }

        public decimal Temp_max { get; set; }
    }

    public class Wind
    {
        public decimal Speed { get; set; }

        public decimal Deg { get; set; }
    }

    public class Clouds
    {
        public string All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public decimal Message { get; set; }

        public string Country { get; set; }

        public long Sunrise { get; set; }

        public long Sunset { get; set; }
    }
}