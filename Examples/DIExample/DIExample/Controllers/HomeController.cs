using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using Autofac;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly ILifetimeScope _lifetimeScope;
        //IServiceScopeFactory _serviceScopeFactory

        public HomeController(ICitiesService citiesService1,
            ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope serviceScopeFactory)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _lifetimeScope = serviceScopeFactory;
            //_citiesService = citiesService;//new CitiesService();
        }
        
        [Route("/")]
        public IActionResult Index(/*[FromServices]ICitiesService _citiesService*/)
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstancedId_citiesService_1 = _citiesService1.ServiceInstanceId;

            ViewBag.InstancedId_citiesService_2 = _citiesService2.ServiceInstanceId;

            ViewBag.InstancedId_citiesService_3 = _citiesService3.ServiceInstanceId;

            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope()) 
            {
                //Inject CitiesService
                ICitiesService citiesService = scope.Resolve<ICitiesService>();
                //DB work

                ViewBag.InstancedId_CitiesServices_InScope = citiesService.ServiceInstanceId;
            }//end of scope; it calls CitiesService.Dispose(_

            return View(cities);
        }
    }
}
