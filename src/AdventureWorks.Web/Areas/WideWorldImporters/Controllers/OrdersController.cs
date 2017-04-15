using Microsoft.AspNetCore.Mvc;
namespace AdventureWorks.Web.Areas.WideWorldImporters.Controllers
{
    [Area("WideWorldImporters")]
    [Route("[area]/[controller]")]
    public class OrdersController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Areas/WideWorldImporters/Views/Shared/_WideWorldImporters.cshtml");
        }
    }
}
