using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repositories;
using AutoMapper;
using AdventureWorks.Web.ViewModels;

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
            return new JsonResult(_mapper.Map<IEnumerable<EmployeeVM>>(_employeeRepository.GetAll()));
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var mapped = _mapper.Map<EmployeeVM>(_employeeRepository.Get(id));
            return new JsonResult(mapped);
        }        
    }
}
