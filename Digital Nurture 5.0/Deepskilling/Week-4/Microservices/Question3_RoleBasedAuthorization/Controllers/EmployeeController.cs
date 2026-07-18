using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Question3_RoleBasedAuthorization.Models;

namespace Question3_RoleBasedAuthorization.Controllers
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

        // Accessible by both Admin and User
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // Accessible by both Admin and User
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
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

        // Only Admin can Add Employee
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        // Only Admin can Update Employee
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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

        // Only Admin can Delete Employee
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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

        // Admin Dashboard
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return Ok(new
            {
                Message = "Welcome Admin!",
                TotalEmployees = employees.Count
            });
        }

        // User Dashboard
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult UserDashboard()
        {
            return Ok(new
            {
                Message = "Welcome User!",
                Access = "You have read-only access."
            });
        }
    }
}