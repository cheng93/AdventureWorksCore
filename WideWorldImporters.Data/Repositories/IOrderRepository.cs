using AdventureWorks.Common.Repositories;
using WideWorldImporters.Data.Models;

namespace WideWorldImporters.Data.Repositories
{
    public interface IOrderRepository : IReadOnlyRepository<Orders, int>
    {
    }
}
