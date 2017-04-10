using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public abstract class ApiController : Controller
    {
        protected IMediator Mediator { get; set; }

        protected ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
