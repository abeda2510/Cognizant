using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Emp")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true
            },

            new Employee
            {
                Id = 2,
                Name = "David",
                Salary = 60000,
                Permanent = false
            }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee? employee =
                employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid Employee Id");
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> Post(
            [FromBody] Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(
            int id,
            [FromBody] Employee employee)
        {
            Employee? existingEmployee =
                employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid Employee Id");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;

            return Ok(existingEmployee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Employee? employee =
                employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid Employee Id");
            }

            employees.Remove(employee);

            return Ok("Employee Deleted Successfully");
        }
    }
}