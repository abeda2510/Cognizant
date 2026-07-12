using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees =
            new List<Employee>
            {
                new Employee
                {
                    Id = 1,

                    Name = "John",

                    Salary = 50000,

                    Permanent = true,

                    Department =
                        new Department
                        {
                            Id = 1,
                            Name = "IT"
                        },

                    Skills =
                        new List<Skill>
                        {
                            new Skill
                            {
                                Id = 1,
                                Name = "C#"
                            },

                            new Skill
                            {
                                Id = 2,
                                Name = "ASP.NET Core"
                            }
                        },

                    DateOfBirth =
                        new DateTime(1995, 5, 15)
                },

                new Employee
                {
                    Id = 2,

                    Name = "David",

                    Salary = 60000,

                    Permanent = false,

                    Department =
                        new Department
                        {
                            Id = 2,
                            Name = "HR"
                        },

                    Skills =
                        new List<Skill>
                        {
                            new Skill
                            {
                                Id = 3,
                                Name = "Communication"
                            }
                        },

                    DateOfBirth =
                        new DateTime(1996, 8, 20)
                }
            };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee? employee =
                employees.FirstOrDefault(
                    e => e.Id == id);

            if (employee == null)
            {
                return BadRequest(
                    "Invalid employee id");
            }

            return Ok(employee);
        }
    }
}