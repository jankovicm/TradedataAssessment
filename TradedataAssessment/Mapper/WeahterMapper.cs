using TradedataAssessment.Models;

namespace TradedataAssessment.Mapper
{
    public class WeahterMapper
    {
        public WeatherResultItemModel FromWeatherEntity(Tradedataassessment.Model.Weather entity)
        {
            var model = new WeatherResultItemModel
            {
                City = entity.CapitalCity.Name,
                Date = entity.Date,
                Country = entity.CapitalCity.Country,
                WindSpeed = entity.WindSpeed,
                WindDirection = entity.WindDirection,
                Sunrise = entity.Sunrise,
                Sunset = entity.Sunset,
                Temperature = entity.Temperature,
                Pressure = entity.Pressure,
                Humidity = entity.Humidity,
                TempMin = entity.TempMin,
                TempMax = entity.TempMax,
                Cloudiness = entity.Cloudiness
            };

            return model;
        }
    }
}