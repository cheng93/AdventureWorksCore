using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Areas.AdventureWorks.Controllers
{
    [Area("AdventureWorks")]
    [Route("[area]/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        [Route("{id}")]
        public IActionResult Index()
        {
            return View("~/Areas/AdventureWorks/Views/Shared/_AdventureWorks.cshtml");
        }
    }
}
