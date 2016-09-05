using System;
using System.Globalization;

namespace TradedataAssessment.Models
{
    public class WeatherResultItemModel
    {
        public DateTime Date { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public decimal? WindSpeed { get; set; }

        public decimal? WindDirection { get; set; }

        public long? Sunrise { get; set; }

        public long? Sunset { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? Pressure { get; set; }

        public decimal? Humidity { get; set; }

        public decimal? TempMin { get; set; }

        public decimal? TempMax { get; set; }

        public decimal? Cloudiness { get; set; }

        public string TemparetureCentigrade
        {
            get
            {
                if (Temperature.HasValue)
                {
                    float originalFarenhait = (float) Temperature.Value;
                    float centigrade = (originalFarenhait - 32)/9*5;
                    return $"{centigrade.ToString(CultureInfo.InvariantCulture)} C";
                }
                return 0.ToString();
            }
        }

        public string CityCountry => $"{City} ({Country})";

        public DateTime SunriseFormatted
        {
            get
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(Sunrise.Value).ToLocalTime();
                return date;
            }
        }

        public DateTime SunsetFormatted
        {
            get
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(Sunset.Value).ToLocalTime();
                return date;
            }
        }

    }
}