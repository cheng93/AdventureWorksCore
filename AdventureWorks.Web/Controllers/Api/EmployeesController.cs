using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        // GET: api/employees
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value: {id}";
        }        
    }
}
