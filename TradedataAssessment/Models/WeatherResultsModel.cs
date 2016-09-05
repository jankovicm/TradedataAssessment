using System.Collections.Generic;

namespace TradedataAssessment.Models
{
    public class WeatherResultsModel : WeatherSearchModel
    {
        public List<WeatherResultItemModel> Results { get; set; }
    }
}