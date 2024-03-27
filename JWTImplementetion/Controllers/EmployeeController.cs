using JWTImplementetion.Interfaces;
using JWTImplementetion.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTImplementetion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
                _employeeServices = employeeServices;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
          return _employeeServices.GetEmployeeDetails();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeServices.GetEmployeeDetails(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee emp)
        {
            //return "Data insert success !!;"
            return _employeeServices.AddEmployee(emp);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee emp)
        {
            return _employeeServices.UpdateEmployee(emp);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _employeeServices.DeleteEmployee(id);    
        }
    }
}
