using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repositories;
using AutoMapper;
using AdventureWorks.Web.ViewModels;
using AdventureWorks.Data.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Areas.AdventureWorks.Controllers.Api
{
    [Area("AdventureWorks")]
    [Route("[area]/api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IEmployeeDepartmentHistoryRepository _employeeDepartmentHistoryRepository;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
        }

        // GET: api/employees
        [HttpGet]
        public JsonResult Get()
        {
            var data = _employeeRepository
                .GetAll()
                .ToList();
            return new JsonResult(data.Select(x => Map(x)));
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var data = _employeeRepository.Get(id);
            return new JsonResult(Map(data));
        }

        // GET api/employees/5/department-histories
        [HttpGet("{id}/department-histories")]
        public JsonResult GetDepartmentHistories(int id)
        {
            var data = _employeeDepartmentHistoryRepository
                .GetHistory(id)
                .ToList();
            return new JsonResult(data.Select(x => Map(x)));
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
