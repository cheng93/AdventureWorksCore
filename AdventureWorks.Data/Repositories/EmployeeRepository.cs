using System.Collections.Generic;
using AdventureWorks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdventureWorks.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IAdventureWorks2014Context _dbContext;

        public EmployeeRepository(IAdventureWorks2014Context dbContext)
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
    }
}
