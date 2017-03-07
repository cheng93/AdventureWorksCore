using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/employees
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_employeeRepository.GetAll());
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_employeeRepository.Get(id));
        }        
    }
}
