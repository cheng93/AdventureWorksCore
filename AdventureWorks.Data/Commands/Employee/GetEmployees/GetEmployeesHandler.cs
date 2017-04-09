using AdventureWorks.Common.Commands.EFCore;
using AdventureWorks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdventureWorks.Data.Commands.Employee.GetEmployees
{
    public class GetEmployeesHandler : AdventureWorksHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        public GetEmployeesHandler(AdventureWorks2014Context dbContext) 
            : base(dbContext)
        {
        }

        public override GetEmployeesResponse Handle(GetEmployeesRequest message)
        {
            var employees = DbContext.Employee
                .Include(x => x.BusinessEntity)
                .Apply(message.Settings)
                .ToList();

            return new GetEmployeesResponse()
            {
                Employees = employees
            };
        }
    }
}
