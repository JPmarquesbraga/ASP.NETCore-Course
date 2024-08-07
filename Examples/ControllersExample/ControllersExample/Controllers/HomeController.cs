using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;
namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            /* return new ContentResult()
             {
                 Content = "Hello from Index",
                 ContentType = "text/plain"
             };
            */
            return Content("Hello from Index", "text/plain");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() { Id = Guid.NewGuid(),
            FirstName = "James", LastName = "Smith", Age = 25};
            //return new JsonResult(person);
            return Json(person);
            //return "{ \"Key\": \"Value\" }";
        }

        [Route("file-dowload")]
        public VirtualFileResult FileDowload()
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-dowload2")]
        public PhysicalFileResult FileDowload2()
        {
            return new PhysicalFileResult(@"c:\aspnetcore\sample.pdf", "application/pdf");
        }

        [Route("file-dowload3")]
        public IActionResult FileDowload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"c:\aspnet\sample.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
