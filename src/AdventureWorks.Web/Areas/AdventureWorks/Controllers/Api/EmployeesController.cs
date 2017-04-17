using AdventureWorks.Data.Commands.Employee.GetEmployee;
using AdventureWorks.Data.Commands.Employee.GetEmployeeHistory;
using AdventureWorks.Data.Commands.Employee.GetEmployees;
using AdventureWorks.Data.Models;
using AdventureWorks.Web.Areas.AdventureWorks.Models;
using AdventureWorks.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Areas.AdventureWorks.Controllers.Api
{
    [Area("AdventureWorks")]
    [Route("[area]/api/[controller]")]
    public class EmployeesController : ApiController
    {
        public EmployeesController(IMediator mediator)
            : base(mediator)
        {
        }

        // GET: api/employees
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var request = new GetEmployeesRequest();
            var response = await Mediator.Send(request);

            return new JsonResult(response.Employees.Select(x => Map(x)));
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var request = new GetEmployeeRequest()
            {
                EmployeeId = id
            };
            var response = await Mediator.Send(request);

            return new JsonResult(Map(response.Employee));
        }

        // GET api/employees/5/department-histories
        [HttpGet("{id}/department-histories")]
        public async Task<JsonResult> GetDepartmentHistories(int id)
        {
            var request = new GetEmployeeHistoryRequest()
            {
                EmployeeId = id
            };
            var response = await Mediator.Send(request);

            return new JsonResult(response.History.Select(x => Map(x)));
        }

        private EmployeeVM Map(Employee employee)
            => new EmployeeVM()
            {
                Id = employee.BusinessEntityId,

                Title = employee.BusinessEntity.Title,
                FirstName = employee.BusinessEntity.FirstName,
                MiddleName = employee.BusinessEntity.MiddleName,
                LastName = employee.BusinessEntity.LastName,
                Suffix = employee.BusinessEntity.Suffix,

                NationalIdnumber = employee.NationalIdnumber,
                LoginId = employee.LoginId,
                OrganizationLevel = employee.OrganizationLevel,
                JobTitle = employee.JobTitle,
                BirthDate = employee.BirthDate,
                MaritalStatus = employee.MaritalStatus,
                Gender = employee.Gender,
                HireDate = employee.HireDate,
                SalariedFlag = employee.SalariedFlag,
                VacationHours = employee.VacationHours,
                SickLeaveHours = employee.SickLeaveHours,
                CurrentFlag = employee.CurrentFlag
            };

        private EmployeeDepartmentHistoryVM Map(EmployeeDepartmentHistory employeeDepartmentHistory)
            => new EmployeeDepartmentHistoryVM()
            {
                EmployeeId = employeeDepartmentHistory.BusinessEntityId,
                Department = Map(employeeDepartmentHistory.Department),
                Start = employeeDepartmentHistory.StartDate,
                End = employeeDepartmentHistory.EndDate
            };

        private DepartmentVM Map(Department department)
            => new DepartmentVM()
            {
                Id = department.DepartmentId,

                Name = department.Name,
                GroupName = department.GroupName
            };
    }
}
