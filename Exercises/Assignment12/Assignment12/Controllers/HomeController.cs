using Assignment12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                order.RandomOrderNum(); 
                return Content($"Order Number: {order.OrderNum}");
            }
            string errors = string.Join("\n", ModelState.Values.SelectMany(value =>
            value.Errors).Select(err => err.ErrorMessage).ToList());

            return BadRequest(errors);
        }
    }
}
