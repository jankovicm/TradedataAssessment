using System.Collections.Generic;
using Tradedataassessment.Model;
using TradedataAssessment.Data;
using TradedataAssessment.Service.Interfaces;

namespace TradedataAssessment.Service.Implementations
{
    public class CapitalCityService : ServiceBase<CapitalCity>, ICapitalCityService
    {
        public CapitalCityService(IRepository<CapitalCity> repository) : base(repository)
        {
            
        }

        public IEnumerable<CapitalCity> GetAllCapitalCities()
        {
            return Repository.FindAll();
        }
    }
}