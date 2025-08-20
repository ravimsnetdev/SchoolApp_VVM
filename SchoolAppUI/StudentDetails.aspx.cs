using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SchoolAppCommon.ViewModels; // Install via NuGet

namespace SchoolAppUI
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        private readonly string apiBaseUrl;

        public StudentDetails()
        {
            apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        }

        public int selectedStudentId {
            get 
            {
                return Convert.ToInt32(Session["SelectedStudentId"]);
            }
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (selectedStudentId > 0)
                {
                    LoadStudent();
                }
                else
                {
                    BindDetails(new Student_VM());
                }
            }
        }

        private async void LoadStudent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"{apiBaseUrl}/{selectedStudentId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var student = JsonConvert.DeserializeObject<Student_VM>(json);

                    BindDetails(student);
                }
            }
        }

        private void BindDetails(Student_VM student)
        {
            if (student != null)
            {
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                txtEditRoll.Text = student.RollNumber;
                ddlClass.SelectedValue = student.Class;
                txtEditSection.Text = student.Section;
                txtDateOfBirth.Text = (student.DateOfBirth != DateTime.MinValue) ? student.DateOfBirth.ToString("yyyy-MM-dd") : string.Empty;
                txtGender.Text = student.Gender;

                lblHeader.Text = (student.StudentId > 0) ? "Edit Student : " + student.Name : "Add Student";
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            var student = new Student_VM
            {
                StudentId = selectedStudentId,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                RollNumber = txtEditRoll.Text,
                Class = ddlClass.SelectedValue,
                Section = txtEditSection.Text,
                DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                Gender = txtGender.Text,
                LastUpdatedBy = "UIUser",
                LastUpdatedDateTime = DateTime.Now,
                FirstInsertedBy = "UIUser",
                FirstInsertedDateTime = DateTime.Now
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                if (student.StudentId > 0) // Update
                {
                    response = await client.PutAsync($"{apiBaseUrl}/{student.StudentId}", content);
                }
                else // Create
                {
                    response = await client.PostAsync(apiBaseUrl, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("StudentSummary.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    // handle error
                    Response.Write("<script>alert('Error saving student!');</script>");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSummary.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void cvDOB_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dob;
            if (DateTime.TryParse(txtDateOfBirth.Text, out dob))
            {
                int age = DateTime.Now.Year - dob.Year;
                if (dob > DateTime.Now.AddYears(-age)) age--; // adjust if birthday not reached
                args.IsValid = age <= 30;
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}
