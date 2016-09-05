using System.Collections.Generic;
using Tradedataassessment.Model;

namespace TradedataAssessment.Service.Interfaces
{
    public interface ICapitalCityService
    {
        IEnumerable<CapitalCity> GetAllCapitalCities();
    }
}