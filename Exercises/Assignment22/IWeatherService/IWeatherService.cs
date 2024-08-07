using Service;

namespace ServiceContract
{
    public interface IWeatherService
    { 
        List<City_Weather> GetCities();
    }
}
