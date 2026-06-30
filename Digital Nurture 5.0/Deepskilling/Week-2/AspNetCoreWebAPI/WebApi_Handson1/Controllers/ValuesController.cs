using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string>
        {
            "Value1",
            "Value2",
            "Value3"
        };

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values);
        }

        // GET by Id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            return Ok(values[id]);
        }

        // POST
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok("Value Added Successfully");
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values[id] = value;

            return Ok("Value Updated Successfully");
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values.RemoveAt(id);

            return Ok("Value Deleted Successfully");
        }
    }
}