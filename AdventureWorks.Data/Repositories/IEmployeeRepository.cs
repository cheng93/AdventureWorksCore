using AdventureWorks.Common.Repositories;
using AdventureWorks.Data.Models;

namespace AdventureWorks.Data.Repositories
{
    public interface IEmployeeRepository : IReadOnlyRepository<Employee, int>
    {
    }
}
