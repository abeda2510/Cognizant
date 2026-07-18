using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Question2_SecureAPIEndpoint.Models;

namespace Question2_SecureAPIEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 101,
                    Name = "Ashok Kumar",
                    Department = "IT",
                    Designation = "Software Engineer",
                    Salary = 50000
                },
                new Employee
                {
                    Id = 102,
                    Name = "Rahul Sharma",
                    Department = "HR",
                    Designation = "HR Executive",
                    Salary = 45000
                },
                new Employee
                {
                    Id = 103,
                    Name = "Priya Reddy",
                    Department = "Finance",
                    Designation = "Accountant",
                    Salary = 55000
                }
            };

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = new Employee
            {
                Id = id,
                Name = "Ashok Kumar",
                Department = "IT",
                Designation = "Software Engineer",
                Salary = 50000
            };

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok(new
            {
                Message = "Employee added successfully.",
                Employee = employee
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            employee.Id = id;

            return Ok(new
            {
                Message = "Employee updated successfully.",
                Employee = employee
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(new
            {
                Message = $"Employee with Id {id} deleted successfully."
            });
        }
    }
}