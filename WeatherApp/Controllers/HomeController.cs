using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models;
using ServiceContracts;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var cities = _weatherService.GetWeatherDetails();
            return View(cities);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult City(string? cityCode) 
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return View();
            }

            CityWeather? city = _weatherService.GetWeatherByCityCode(cityCode);

            return View(city);
        }
    }
}
