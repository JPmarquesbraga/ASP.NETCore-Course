using ServiceContract;
using System.Runtime.InteropServices;

namespace Service
{
    public class WeatherService : IWeatherService
    {
        private List<City_Weather> _Weathers;

        public WeatherService()
        { 
            _Weathers = new List<City_Weather>()
            {
                new City_Weather { CityUniqueCode = "LDN", CityName = "London",
                    DateAndTime = DateTime.Parse("2030-01-01 8:00"),TemperatureFahrenheit = 33},
                new City_Weather { CityUniqueCode = "NYC", CityName = "New York",
                    DateAndTime = DateTime.Parse("2030-01-01 3:00"),TemperatureFahrenheit = 60},
                new City_Weather { CityUniqueCode = "PAR", CityName = "Paris",
                    DateAndTime = DateTime.Parse("2030-01-01 9:00"),TemperatureFahrenheit = 82},
            };
        }

        public List<City_Weather> GetCities()
        {
            return _Weathers;
        }

    }
}
