using System;

namespace AdventureWorks.Web.ViewModels
{
    public class EmployeeDepartmentHistoryVM
    {
        public int EmployeeId { get; set; }
        public DepartmentVM Department { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
