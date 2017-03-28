using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repositories;
using AutoMapper;
using AdventureWorks.Web.ViewModels;
using AdventureWorks.Data.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: api/employees
        [HttpGet]
        public JsonResult Get()
        {
            var mapped = _employeeRepository
                .GetAll()
                .ToList()
                .Select(x => Map(x));
            return new JsonResult(mapped);
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var mapped = Map(_employeeRepository.Get(id));
            return new JsonResult(mapped);
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
    }
}
