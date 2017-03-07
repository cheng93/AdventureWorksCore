using AdventureWorks.Data.Models;
using AdventureWorks.Data.Repositories.Common;

namespace AdventureWorks.Data.Repositories
{
    public interface IEmployeeRepository : IReadOnlyRepository<Employee, int>
    {
    }
}
