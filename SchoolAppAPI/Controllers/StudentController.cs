using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolAppCommon.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student_VM> Get()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var studentsList = new List<Student_VM>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = @"
                SELECT [StudentId], [FirstName], [LastName], [RollNumber],
                       [Class], [Section], [DateOfBirth], [Gender],
                       [FirstInsertedBy], [FirstInsertedDateTime],
                       [LastUpdatedBy], [LastUpdatedDateTime]
                FROM [SCHOOL_APP_VVM].[dbo].[Student]";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentsList.Add(new Student_VM
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                Name = Convert.ToString(reader["FirstName"]) + " " + Convert.ToString(reader["LastName"]),
                                RollNumber = Convert.ToString(reader["RollNumber"]),
                                Class = Convert.ToString(reader["Class"]),
                                Section = Convert.ToString(reader["Section"]),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                FirstInsertedBy = Convert.ToString(reader["FirstInsertedBy"]),
                                FirstInsertedDateTime = Convert.ToDateTime(reader["FirstInsertedDateTime"]),
                                LastUpdatedBy = Convert.ToString(reader["LastUpdatedBy"]),
                                LastUpdatedDateTime = Convert.ToDateTime(reader["LastUpdatedDateTime"])
                            });
                        }
                    }
                }
            }

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
