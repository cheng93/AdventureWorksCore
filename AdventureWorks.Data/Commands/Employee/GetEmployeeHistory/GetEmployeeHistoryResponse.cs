using AdventureWorks.Data.Models;
using System.Collections.Generic;

namespace AdventureWorks.Data.Commands.Employee.GetEmployeeHistory
{
    public class GetEmployeeHistoryResponse
    {
        public IEnumerable<EmployeeDepartmentHistory> History { get; set; }
    }
}
