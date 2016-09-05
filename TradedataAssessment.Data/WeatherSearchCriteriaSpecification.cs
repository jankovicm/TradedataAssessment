using System;
using System.Linq.Expressions;
using Tradedataassessment.Model;
using TradedataAssessment.Model.Contracts;

namespace TradedataAssessment.Data
{
    public class WeatherSearchCriteriaSpecification : ISpecification<Weather>
    {
        private readonly string _cityName;
        private readonly DateTime? _date;
        private readonly decimal? _temperatureFrom;
        private readonly decimal? _temperatureTo;
        private readonly long? _sunriseFrom;
        private readonly long? _sunriseTo;

        public WeatherSearchCriteriaSpecification(WeatherSearchCriteria searchCriteria)
        {
            _cityName = searchCriteria.CityName?.ToLower() ?? string.Empty;
            
            _date = searchCriteria.Date;
            _temperatureFrom = searchCriteria.TemperatureFrom;
            _temperatureTo = searchCriteria.TemperatureTo;

            if (searchCriteria.SunriseFrom.HasValue)
            {
                _sunriseFrom = (long)(TimeZoneInfo.ConvertTimeToUtc(searchCriteria.SunriseFrom.Value) -
                     new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
            }

            if (searchCriteria.SunriseTo.HasValue)
            {
                _sunriseTo = (long)(TimeZoneInfo.ConvertTimeToUtc(searchCriteria.SunriseTo.Value) -
                     new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
            }

        }

        public Expression<Func<Weather, bool>> IsSatisfied()
        {
            return x => (string.IsNullOrEmpty(_cityName) || x.CapitalCity.Name.ToLower().Contains(_cityName))
                        && (!_date.HasValue || (x.Date.Year == _date.Value.Year && x.Date.Month == _date.Value.Month && x.Date.Day == _date.Value.Day))
                        && (!_temperatureFrom.HasValue || x.Temperature >= _temperatureFrom.Value)
                        && (!_temperatureTo.HasValue || x.Temperature <= _temperatureTo.Value)
                        && (!_sunriseFrom.HasValue || x.Sunrise >= _sunriseFrom)
                        && (!_sunriseTo.HasValue || x.Sunrise <= _sunriseTo);
        }
    }
}
