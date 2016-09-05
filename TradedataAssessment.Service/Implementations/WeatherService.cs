using System.Collections.Generic;
using System.Linq;
using Tradedataassessment.Model;
using TradedataAssessment.Data;
using TradedataAssessment.Service.Interfaces;

namespace TradedataAssessment.Service.Implementations
{
    public class WeatherService : ServiceBase<Weather>, IWeatherService
    {
        public WeatherService(IRepository<Weather> repository) : base(repository)
        {
        }

        public void Add(Weather data)
        {
            Repository.Add(data);
        }

        public void SaveChanges()
        {
            Repository.SaveChanges();
        }

        public IEnumerable<Weather> AllWeatherData()
        {
            return Repository.FindAll();
        }

        public IEnumerable<Weather> FindWeatherData(WeatherSearchCriteria searchCriteria)
        {
            var spec = new WeatherSearchCriteriaSpecification(searchCriteria);
            return Repository.FindAll().Where(spec.IsSatisfied());
        }
    }
}