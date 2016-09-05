using System.Collections.Generic;
using Tradedataassessment.Model;
using TradedataAssessment.Data;

namespace TradedataAssessment.Service.Interfaces
{
    public interface IWeatherService
    {
        void Add(Weather data);

        void SaveChanges();

        IEnumerable<Weather> AllWeatherData();

        IEnumerable<Weather> FindWeatherData(WeatherSearchCriteria searchCriteria);
    }
}