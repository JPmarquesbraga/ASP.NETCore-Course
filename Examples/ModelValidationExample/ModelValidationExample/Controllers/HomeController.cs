﻿using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Models;
namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //[Bind(nameof(Person.PersonName), nameof(Person.Email),
        //nameof(Person.Password), nameof(Person.ConfirmPassword))]
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")]string UserAgent)
        {
            if (!ModelState.IsValid) 
            { 
                string errors = string.Join("\n", ModelState.Values.SelectMany(value =>
                value.Errors).Select(err => err.ErrorMessage).ToList());
                            
                return BadRequest(errors);
            }
            return Content($"{person}, {UserAgent}");                
        }
    }
}
