using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index([FromRoute]int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            if (bookid.HasValue == false)
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                return BadRequest("Book id is not supplied");
            }

            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id cant be null or empty");
                return BadRequest("Book id cant be null or empty");
            }

            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id cant be less or equal than zero");
                return BadRequest("Book id cant be less or equal than zero");
            }
            if (bookId > 1000)
            {
                //Response.StatusCode = 404;
                //return Content("Book id cant be greater than 1000");
                return NotFound("Book id cant be greater than 1000");
            }

            if (isloggedin == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");
                return Unauthorized("User must be authenticated");
            }

            //return RedirectToAction("Books", "Store", new {id = bookId});

            //return new RedirectToActionResult("Books", "Store", new { }, true);
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });
            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
            //return new LocalRedirectResult($"store/books/{bookId}");
        }
    }
}
