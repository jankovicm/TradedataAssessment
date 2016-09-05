using System.Web.Mvc;
using TradedataAssessment.Models;

namespace TradedataAssessment.Code
{
    public static partial class UrlHelperExtensions
    {
        public static string GetWeatherData(this UrlHelper url)
        {
            return url.Action("GetWeather", "Home", new { area = string.Empty });
        }

        public static string ViewWeatherData(this UrlHelper url)
        {
            return url.Action("Data", "Home", new { area = string.Empty });
        }

        public static string SearchWeatherData(this UrlHelper url, WeatherSearchModel searchModel)
        {
            if (searchModel == null) return url.Action("Data", "Home", new { area = string.Empty });
            return url.Action("Data", "Home", new
            {
                area = string.Empty,
                searchModel.Date,
                searchModel.CityName,
                searchModel.SunriseFrom,
                searchModel.SunriseTo,
                searchModel.TemperatureFrom,
                searchModel.TemperatureTo
            });
        }
    }
}