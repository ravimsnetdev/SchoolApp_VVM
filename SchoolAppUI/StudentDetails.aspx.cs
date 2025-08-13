using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SchoolAppCommon.ViewModels;

namespace SchoolAppUI
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var selecetdStdId = Convert.ToInt32(Session["SelectedStudentId"]);

                var selecetdStudent = Students.Where(x => x.StudentId == selecetdStdId).FirstOrDefault();

                if (selecetdStudent != null)
                {
                    txtFirstName.Text = selecetdStudent.FirstName;
                    txtLastName.Text = selecetdStudent.LastName;
                    txtEditRoll.Text = selecetdStudent.RollNumber;
                    txtEditClass.Text = selecetdStudent.Class;
                    txtEditSection.Text = selecetdStudent.Section;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["SelectedStudentId"]);
            var student = Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.RollNumber = txtEditRoll.Text;
                student.Class = txtEditClass.Text;
                student.Section = txtEditSection.Text;
            }

            string apiUrl = "https://localhost:44330/api/Student";

            using (var httpClient = new HttpClient())

            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("StudentSummary.aspx");
                }
                else
                {
                    //alert 
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSummary.aspx");
        }

        private List<Student_VM> Students
        {
            get
            {
                return (List<Student_VM>)Session["Students"];
            }
            set { Session["Students"] = value; }
        }
    }
}