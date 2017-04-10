using AdventureWorks.Common.Commands.EFCore;
using AdventureWorks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdventureWorks.Data.Commands.Employee.GetEmployeeHistory
{
    public class GetEmployeeHistoryHandler : AdventureWorksHandler<GetEmployeeHistoryRequest, GetEmployeeHistoryResponse>
    {
        public GetEmployeeHistoryHandler(AdventureWorks2014Context dbContext) 
            : base(dbContext)
        {
        }

        public override GetEmployeeHistoryResponse Handle(GetEmployeeHistoryRequest message)
        {
            var history = DbContext.EmployeeDepartmentHistory
                .Include(x => x.Department)
                .Where(x => x.BusinessEntityId == message.EmployeeId)
                .Apply(message.Settings)
                .ToList();

            return new GetEmployeeHistoryResponse()
            {
                History = history
            };
        }
    }
}
