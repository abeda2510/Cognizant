using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,

                    Department = new Department
                    {
                        Id = 1,
                        Name = "IT"
                    },

                    Skills = new List<Skill>
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

                    DateOfBirth = new DateTime(1995, 5, 15)
                },

                new Employee
                {
                    Id = 2,
                    Name = "David",
                    Salary = 60000,
                    Permanent = false,

                    Department = new Department
                    {
                        Id = 2,
                        Name = "HR"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Communication"
                        }
                    },

                    DateOfBirth = new DateTime(1996, 8, 20)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(
            typeof(List<Employee>),
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("standard")]
        [ProducesResponseType(
            typeof(Employee),
            StatusCodes.Status200OK)]
        public ActionResult<Employee> GetStandard()
        {
            return Ok(employees.First());
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
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return Ok(existingEmployee);
        }

        [HttpGet("exception")]
        [ProducesResponseType(
            StatusCodes.Status500InternalServerError)]
        public ActionResult GenerateException()
        {
            throw new Exception(
                "Custom Exception Generated"
            );
        }
    }
}