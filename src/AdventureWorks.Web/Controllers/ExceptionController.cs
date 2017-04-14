using Microsoft.AspNetCore.Mvc;
using System;

namespace AdventureWorks.Web.Controllers
{
    public class ExceptionController : Controller
    {
        public IActionResult Exception()
        {
            throw new Exception("outer exception", new Exception("inner exception"));
        }
    }
}
