using Microsoft.AspNetCore.Mvc;
using SchoolAppCommon.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student_VM> Get()
        {
            var studentsList = new List<Student_VM>
            { 
                new Student_VM { ID = 1, Name = "Seelam Ravi", RollNo = "101", Class = "12", Section = "A" },
                new Student_VM { ID = 2, Name = "Vishnu", RollNo = "102", Class = "9", Section = "C" },
                new Student_VM { ID = 3, Name = "Mamatha", RollNo = "103", Class = "8", Section = "B" },
                new Student_VM { ID = 4, Name = "Vivek", RollNo = "104", Class = "7", Section = "A" },
            };

            return studentsList;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
