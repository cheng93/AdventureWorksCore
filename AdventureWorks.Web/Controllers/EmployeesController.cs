using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Id = id;
            return View("Employee");
        }
    }
}
