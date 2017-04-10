﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Areas.AdventureWorks.Controllers
{
    [Area("AdventureWorks")]
    [Route("[area]/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [HttpGet("{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}