using System;
using System.ComponentModel;

namespace TradedataAssessment.Models
{
    public class WeatherSearchModel
    {
        [DisplayName("City")]
        public string CityName { get; set; }

        [DisplayName("Date")]
        public DateTime? Date { get; set; }

        [DisplayName("Temperature from")]
        public decimal? TemperatureFrom { get; set; }

        [DisplayName("to")]
        public decimal? TemperatureTo { get; set; }

        [DisplayName("Sunrise from")]
        public DateTime? SunriseFrom { get; set; }

        [DisplayName("to")]
        public DateTime? SunriseTo { get; set; }
    }
}