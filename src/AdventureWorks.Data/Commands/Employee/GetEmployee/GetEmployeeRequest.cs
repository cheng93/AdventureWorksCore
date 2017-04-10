using MediatR;

namespace AdventureWorks.Data.Commands.Employee.GetEmployee
{
    public class GetEmployeeRequest : IRequest<GetEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
}
