using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

using Assignment10.Models;

namespace Assignment10.Controllers
{
    [Controller]
    public class BankController : Controller
    {
        [Route("/")]
        public ContentResult Index()
        {
            return Content("Welcome to the best Bank");
        }


        [Route("account-details")]
        public JsonResult BankAccount()
        {
            BankAccount bankAccount = new BankAccount() { AccountNumber = 1001,
            AccountName = "Flavio", Balance = 5000};
            return Json(bankAccount);
        }

        [Route("get-current-balance/{id:int?}")]
        public IActionResult CurrentBalance()
        {
            if (!Request.RouteValues.ContainsKey("id")) 
            {
                return NotFound("Account Number should be supplied");
            }

            if (Convert.ToInt32(Request.RouteValues["id"]) == 1001)
            {
                return Content("5000");
            }
            return Content("Account number is incorrect");
        }

        [Route("account-statement")]
        public IActionResult PDFFile()
        {
            return File("/samplepdf.pdf", "application/pdf");
        }
    }
}
