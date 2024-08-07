using Assignment14.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment14.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> data = new List<CityWeather>()
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London",
                    DateAndTime = DateTime.Parse("2030-01-01 8:00"),TemperatureFahrenheit = 33},
                new CityWeather { CityUniqueCode = "NYC", CityName = "New York",
                    DateAndTime = DateTime.Parse("2030-01-01 3:00"),TemperatureFahrenheit = 60},
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris",
                    DateAndTime = DateTime.Parse("2030-01-01 9:00"),TemperatureFahrenheit = 82},
            };
            return View("Index", data);
        }

        [Route("weather/{CityUniqueCode}")]
        public IActionResult Details(string? CityUniqueCode)
        {
            if (CityUniqueCode == null)
            {
                return Content("City Code cant be null");
            }

            List<CityWeather> data = new List<CityWeather>()
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London",
                    DateAndTime = DateTime.Parse("2030-01-01 8:00"),TemperatureFahrenheit = 33},
                new CityWeather { CityUniqueCode = "NYC", CityName = "New York",
                    DateAndTime = DateTime.Parse("2030-01-01 3:00"),TemperatureFahrenheit = 60},
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris",
                    DateAndTime = DateTime.Parse("2030-01-01 9:00"),TemperatureFahrenheit = 82},
            };
            CityWeather? matchingCity = data.Where(temp => temp.CityUniqueCode == CityUniqueCode).FirstOrDefault();
            return View(matchingCity);
        }
    }
}
