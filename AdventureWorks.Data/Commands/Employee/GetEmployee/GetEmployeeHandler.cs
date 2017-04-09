using AdventureWorks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdventureWorks.Data.Commands.Employee.GetEmployee
{
    public class GetEmployeeHandler : AdventureWorksHandler<GetEmployeeRequest, GetEmployeeResponse>
    {
        public GetEmployeeHandler(AdventureWorks2014Context dbContext) 
            : base(dbContext)
        {
        }

        public override GetEmployeeResponse Handle(GetEmployeeRequest message)
        {
            var employee = DbContext.Employee
                .Include(x => x.BusinessEntity)
                .SingleOrDefault(x => x.BusinessEntityId == message.EmployeeId);

            return new GetEmployeeResponse()
            {
                Employee = employee
            };
        }
    }
}
