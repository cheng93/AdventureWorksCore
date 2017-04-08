using System.Collections.Generic;
using AdventureWorks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdventureWorks.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IEmployeeDepartmentHistoryRepository
    {
        private readonly AdventureWorks2014Context _dbContext;

        public EmployeeRepository(AdventureWorks2014Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Get(int id) =>
            _dbContext.Employee
                .Include(x => x.BusinessEntity)
                .SingleOrDefault(x => x.BusinessEntityId == id);

        public IEnumerable<Employee> GetAll() =>
            _dbContext.Employee
                .Include(x => x.BusinessEntity);

        public IEnumerable<EmployeeDepartmentHistory> GetHistory(int employeeId) =>
            _dbContext.EmployeeDepartmentHistory
                .Include(x => x.Department)
                .Where(x => x.BusinessEntityId == employeeId);
    }
}
