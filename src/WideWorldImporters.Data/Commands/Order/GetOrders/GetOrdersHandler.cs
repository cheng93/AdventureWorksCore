using AdventureWorks.Common.Commands.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WideWorldImporters.Data.Models;

namespace WideWorldImporters.Data.Commands.Order.GetOrders
{
    public class GetOrdersHandler : WideWorldImportersHandler<GetOrdersRequest, GetOrdersResponse>
    {
        public GetOrdersHandler(WideWorldImportersContext dbContext) 
            : base(dbContext)
        {
        }

        public override GetOrdersResponse Handle(GetOrdersRequest message)
        {
            var orders = DbContext.Orders
                .Include(x => x.Customer)
                .Apply(message.Settings)
                .ToList();

            return new GetOrdersResponse()
            {
                Orders = orders
            };
        }
    }
}
