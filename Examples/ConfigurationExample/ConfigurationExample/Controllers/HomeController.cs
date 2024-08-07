using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOption _options;

        public HomeController(IOptions<WeatherApiOption> weatherÁpiOptions)
        {
            _options = weatherÁpiOptions.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //WeatherApiOption option = 
            //_configuration.GetSection("weatherapi").Get<WeatherApiOption>();

            /*Bind: Load configuration values into existing Options object
            WeatherApiOption option = new WeatherApiOption();
            _configuration.GetSection("weatherapi").Bind(option);
            */

            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;
            return View();         
        }
    }
}
