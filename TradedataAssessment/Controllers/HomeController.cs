using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TradedataAssessment.Code;
using TradedataAssessment.Common.Extensions;
using TradedataAssessment.Data;
using TradedataAssessment.Mapper;
using TradedataAssessment.Models;
using TradedataAssessment.Service.Interfaces;
using Weather = Tradedataassessment.Model.Weather;

namespace TradedataAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICapitalCityService _capitalCityService;
        private readonly IWeatherService _weatherService;

        public HomeController(ICapitalCityService capitalCityService, IWeatherService weatherService)
        {
            _capitalCityService = capitalCityService;
            _weatherService = weatherService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> GetWeather()
        {
            var cityIds = _capitalCityService.GetAllCapitalCities().Select(x => x.CityId).ToArray();
            var weatherData = await GetWeatherDataFromApi(cityIds);
            await SaveWeatherData(weatherData);

            return View();
        }

        public async Task SaveWeatherData(WeatherData data)
        {
            var t = data.Data;

            if (data.Data != null && data.Data.Any())
            {
                foreach (var item in t)
                {
                    var weatherDomain = new Weather
                    {
                        City_Id = item.CityId,
                        Date = DateTime.Now,
                        WindSpeed = item.WindParameters.Speed,
                        WindDirection = item.WindParameters.Deg,
                        Sunrise = item.Parameters.Sunrise,
                        Sunset = item.Parameters.Sunset,
                        Temperature = item.WeatherParameters.Temp,
                        Pressure = item.WeatherParameters.Pressure,
                        Humidity = item.WeatherParameters.Humidity,
                        TempMin = item.WeatherParameters.Temp_min,
                        TempMax = item.WeatherParameters.Temp_max
                    };

                    _weatherService.Add(weatherDomain);
                    _weatherService.SaveChanges();
                }
            }
        }

        private static async Task<WeatherData> GetWeatherDataFromApi(IEnumerable<int> cityIds)
        {
            const string apiKey = "617506510c47a349c4cfa3d68b8f4801";
            const string apiUrl = "http://api.openweathermap.org/data/2.5/group";

            var uri = new StringBuilder(apiUrl);
            uri.Append("?APPID=617506510c47a349c4cfa3d68b8f4801");
            uri.Append("&id=").Append(cityIds.JoinWithComma());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(uri.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var weatherData = await response.Content.ReadAsAsync<WeatherData>();
                    return weatherData;
                }
            }

            return new WeatherData { TotalItems = 0 };
        }

        public ActionResult Data(WeatherSearchModel model)
        {
            var weatherSearchCriteria = new WeatherSearchCriteria
            {
                CityName = model.CityName,
                Date = model.Date,
                TemperatureFrom = model.TemperatureFrom,
                TemperatureTo = model.TemperatureTo,
                SunriseFrom = model.SunriseFrom,
                SunriseTo = model.SunriseTo
            };

            var weatherData = _weatherService.FindWeatherData(weatherSearchCriteria);
            var mapper = new WeahterMapper();
            var results = weatherData.Select(result => mapper.FromWeatherEntity(result)).ToList();

            var resultModel = new WeatherResultsModel { Results = results };
            return View(resultModel);
        }

        //[HttpPost]
        public ActionResult Search(WeatherSearchModel model)
        {
            return Redirect(Url.SearchWeatherData(model));
            //var weatherSearchCriteria = new WeatherSearchCriteria
            //{
            //    CityName = model.CityName,
            //    Date = model.Date,
            //    TemperatureFrom = model.TemperatureFrom,
            //    TemperatureTo = model.TemperatureTo,
            //    SunriseFrom = model.SunriseFrom,
            //    SunriseTo = model.SunriseTo
            //};

            //var weatherData = _weatherService.FindWeatherData(weatherSearchCriteria);
            //var mapper = new WeahterMapper();
            //var results = weatherData.Select(result => mapper.FromWeatherEntity(result)).ToList();
            //var resultModel = new WeatherResultsModel { Results = results };

            //return View("Data", resultModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}