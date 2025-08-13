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
        public IEnumerable<Student_VM> GetAllStudents()
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
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
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
        public string GetStudentById(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student_VM student)
        {
            if (student == null)
                return BadRequest("Student data is null.");

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = @"
            INSERT INTO [dbo].[Student]
                ([FirstName], [LastName], [RollNumber], [Class], [Section], [DateOfBirth], [Gender], [FirstInsertedBy], [FirstInsertedDateTime], [LastUpdatedBy], [LastUpdatedDateTime])
            VALUES
                (@FirstName, @LastName, @RollNumber, @Class, @Section, @DateOfBirth, @Gender, @FirstInsertedBy, @FirstInsertedDateTime, @LastUpdatedBy, @LastUpdatedDateTime)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                    command.Parameters.AddWithValue("@Class", student.Class);
                    command.Parameters.AddWithValue("@Section", student.Section);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", student.Gender);

                    command.Parameters.AddWithValue("@FirstInsertedBy", "LoggedInUser");
                    command.Parameters.AddWithValue("@FirstInsertedDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@LastUpdatedBy", "LoggedInUser");
                    command.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        return Ok("Student added successfully.");
                    else
                        return StatusCode(500, "Error inserting student.");
                }
            }
        }


        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void UpdateStudent(int id, [FromBody] string value)
        {
            var s = "Vishnu";
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
        }
    }
}
