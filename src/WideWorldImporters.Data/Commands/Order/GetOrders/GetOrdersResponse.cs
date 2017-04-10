using System.Collections.Generic;

namespace WideWorldImporters.Data.Commands.Order.GetOrders
{
    public class GetOrdersResponse
    {
        public IEnumerable<Models.Orders> Orders { get; set; }
    }
}
