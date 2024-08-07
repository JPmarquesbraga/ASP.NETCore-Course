using Assignment22.Models;
using ServiceContract;
using Service;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment22.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;
        
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<City_Weather> index = _weatherService.GetCities();
            return View(index);
        }

        [Route("weather/{CityUniqueCode?}")]
        public IActionResult Details(string? CityUniqueCode)
        {
            List<City_Weather> details = _weatherService.GetCities();

            City_Weather? matchingCity = details.Where(temp => temp.CityUniqueCode == CityUniqueCode).FirstOrDefault();
            return View(matchingCity);  
        }
    }
}
