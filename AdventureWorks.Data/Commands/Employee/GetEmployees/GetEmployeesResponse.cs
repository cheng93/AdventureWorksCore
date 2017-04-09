using System.Collections.Generic;

namespace AdventureWorks.Data.Commands.Employee.GetEmployees
{
    public class GetEmployeesResponse
    {
        public IEnumerable<Models.Employee> Employees { get; set; }
    }
}
