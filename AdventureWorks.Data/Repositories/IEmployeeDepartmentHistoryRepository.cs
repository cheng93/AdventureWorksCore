using AdventureWorks.Data.Models;
using System.Collections.Generic;

namespace AdventureWorks.Data.Repositories
{
    public interface IEmployeeDepartmentHistoryRepository
    {
        IEnumerable<EmployeeDepartmentHistory> GetHistory(int employeeId);
    }
}
