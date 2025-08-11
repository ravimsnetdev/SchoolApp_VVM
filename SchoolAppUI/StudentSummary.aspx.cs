using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace SchoolAppUI
{
    public partial class StudentSummary : System.Web.UI.Page
    {

        private readonly HttpClient _httpClient = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private List<Student> Students
        {
            get
            {

                if (Session["Students"] == null)
                {
                    string apiUrl = "https://localhost:7240/api/Sudent";

                    using (WebClient client = new WebClient())
                    {
                        // Set headers if needed (e.g., Content-Type for POST requests)
                        // client.Headers[HttpRequestHeader.ContentType] = "application/json";

                        // For GET requests:
                        string response = client.DownloadString(apiUrl);

                        //lblData.Text = "API Response: " + response;

                        var listStudents = JsonConvert.DeserializeObject<List<Student>>(response);

                        Session["Students"] = listStudents;
                    }
                }
                return (List<Student>)Session["Students"];
            }
            set { Session["Students"] = value; }
        }

        private void BindGrid()
        {
            gvStudents.DataSource = Students;
            gvStudents.DataBind();
        }

        protected void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditRow")
            {

                Session["SelectedStudentId"] = id;

                    //Redirect to details and pass the selected Student

                    Response.Redirect("StudentDetails.aspx");
                
            }
            else if (e.CommandName == "DeleteRow")
            {
                Students = Students.Where(s => s.ID != id).ToList();
                BindGrid();
            }
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://localhost:7240/api/Sudent";

            using (WebClient client = new WebClient())
            {
                // Set headers if needed (e.g., Content-Type for POST requests)
                // client.Headers[HttpRequestHeader.ContentType] = "application/json";

                // For GET requests:
                string response = client.DownloadString(apiUrl);

                lblData.Text = "API Response: " + response;

                var listStudents = JsonConvert.DeserializeObject<List<Student>>(response);

                gvStudents.DataSource = listStudents;
                gvStudents.DataBind();
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
    }
}

