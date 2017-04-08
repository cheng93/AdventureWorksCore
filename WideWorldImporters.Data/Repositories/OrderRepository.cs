using System.Collections.Generic;
using System.Linq;
using WideWorldImporters.Data.Models;

namespace WideWorldImporters.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WideWorldImportersContext _dbContext;

        public OrderRepository(WideWorldImportersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Orders Get(int id) =>
            _dbContext.Orders
                .SingleOrDefault(x => x.OrderId == id);


        public IEnumerable<Orders> GetAll() => _dbContext.Orders;
    }
}
