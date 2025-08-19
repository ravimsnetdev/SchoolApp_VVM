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
        public ActionResult<Student_VM> GetStudentById(int id)
        {
            Student_VM student = null;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM Student WHERE StudentId = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new Student_VM
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            RollNumber = reader["RollNumber"].ToString(),
                            Class = reader["Class"].ToString(),
                            Section = reader["Section"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = reader["Gender"].ToString(),
                            FirstInsertedBy = reader["FirstInsertedBy"].ToString(),
                            FirstInsertedDateTime = Convert.ToDateTime(reader["FirstInsertedDateTime"]),
                            LastUpdatedBy = reader["LastUpdatedBy"].ToString(),
                            LastUpdatedDateTime = Convert.ToDateTime(reader["LastUpdatedDateTime"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        };
                    }
                }
            }

            if (student == null)
                return NotFound();

            return Ok(student);
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
        public ActionResult UpdateStudent(int id, [FromBody] Student_VM student)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Student SET 
                        RollNumber=@RollNumber, Class=@Class, Section=@Section, DateOfBirth=@DateOfBirth, Gender=@Gender, 
                        LastUpdatedBy=@LastUpdatedBy, LastUpdatedDateTime=@LastUpdatedDateTime, FirstName=@FirstName, LastName=@LastName
                    WHERE StudentId=@StudentId", connection);

                cmd.Parameters.AddWithValue("@StudentId", id);
                cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Section", student.Section);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@LastUpdatedBy", "LoggedInUser");
                cmd.Parameters.AddWithValue("@LastUpdatedDateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);

                var rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    return NotFound("Student not found");
            }

            return Ok("Student Updated Successfully");
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM Student WHERE StudentId=@StudentId", connection);
                cmd.Parameters.AddWithValue("@StudentId", id);

                var rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    return NotFound("Student not found");
            }

            return Ok("Student Deleted Successfully");
        }
    }
}
