using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Question4_JWTExpiryHandling.Models;

namespace Question4_JWTExpiryHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Ashok Kumar",
                Department = "IT",
                Designation = "Software Engineer",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul Sharma",
                Department = "HR",
                Designation = "HR Executive",
                Salary = 45000
            },
            new Employee
            {
                Id = 3,
                Name = "Priya Reddy",
                Department = "Finance",
                Designation = "Accountant",
                Salary = 55000
            }
        };

        // Get All Employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // Get Employee By Id
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(new
                {
                    Message = "Employee not found."
                });
            }

            return Ok(employee);
        }

        // Add Employee
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);

            return Ok(new
            {
                Message = "Employee added successfully.",
                Employee = employee
            });
        }

        // Update Employee
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound(new
                {
                    Message = "Employee not found."
                });
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.Salary = employee.Salary;

            return Ok(new
            {
                Message = "Employee updated successfully.",
                Employee = existingEmployee
            });
        }

        // Delete Employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(new
                {
                    Message = "Employee not found."
                });
            }

            employees.Remove(employee);

            return Ok(new
            {
                Message = $"Employee with Id {id} deleted successfully."
            });
        }

        // Protected endpoint to demonstrate JWT expiry
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok(new
            {
                Message = "JWT Token is valid.",
                Time = DateTime.Now,
                Note = "If the JWT token expires (configured for 1 minute), ASP.NET Core automatically returns 401 Unauthorized."
            });
        }
    }
}