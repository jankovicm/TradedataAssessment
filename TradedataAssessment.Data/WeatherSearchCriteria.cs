using System;

namespace TradedataAssessment.Data
{
    public class WeatherSearchCriteria
    {
        public string CityName { get; set; }

        public DateTime? Date { get; set; }

        public decimal? TemperatureFrom { get; set; }

        public decimal? TemperatureTo { get; set; }

        public DateTime? SunriseFrom { get; set; }

        public DateTime? SunriseTo { get; set; }
    }
}