using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WideWorldImporters.Data.Repositories;

namespace AdventureWorks.Web.Areas.WideWorldImporters.Controllers.Api
{
    [Area("WideWorldImports")]
    [Route("[area]/api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/orders
        [HttpGet]
        public JsonResult Get()
        {
            var data = _orderRepository
                .GetAll()
                .ToList();
            return new JsonResult(data);
        }
    }
}
