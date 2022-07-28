using EmployeeManager.API.Models;
using EmployeeManager.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository = null;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        //URL to call this method: localhost/api/employees
        [HttpGet]
        public List<Employee> Get()
        {
            return employeeRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.SelectByID(id);
        }

        //URL to call this method: localhost/api/employees
        //The data will come from the form and will be called from action with POST method in Client
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Insert(emp);
            }
        }

        //URL to call this method: localhost/api/employees/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(emp);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Delete(id);
            }
        }
    }
}
