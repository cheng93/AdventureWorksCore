using AdventureWorks.Common.Commands;

namespace AdventureWorks.Data.Commands.Employee.GetEmployeeHistory
{
    public class GetEmployeeHistoryRequest : Request<GetEmployeeHistoryResponse>
    {
        public int EmployeeId { get; set; }
    }
}
