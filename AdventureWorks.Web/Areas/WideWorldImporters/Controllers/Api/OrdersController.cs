using AdventureWorks.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WideWorldImporters.Data.Commands.Order.GetOrders;

namespace AdventureWorks.Web.Areas.WideWorldImporters.Controllers.Api
{
    [Area("WideWorldImporters")]
    [Route("[area]/api/[controller]")]
    public class OrdersController : ApiController
    {
        public OrdersController(IMediator mediator)
            : base(mediator)
        {
        }

        // GET: api/orders
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var request = new GetOrdersRequest();
            var response = await Mediator.Send(request);

            return new JsonResult(response.Orders);
        }
    }
}
