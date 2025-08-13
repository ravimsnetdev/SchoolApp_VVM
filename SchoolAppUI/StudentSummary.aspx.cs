using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SchoolAppCommon.ViewModels;

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

        private List<Student_VM> Students
        {
            get
            {

                if (Session["Students"] == null)
                {
                    string apiUrl = "https://localhost:44330/api/Student";

                    using (WebClient client = new WebClient())
                    {
                        string response = client.DownloadString(apiUrl);

                        var listStudents = JsonConvert.DeserializeObject<List<Student_VM>>(response);

                        Session["Students"] = listStudents;
                    }
                }
                return (List<Student_VM>)Session["Students"];
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

                Response.Redirect("StudentDetails.aspx");
                
            }
            else if (e.CommandName == "DeleteRow")
            {
                Students = Students.Where(s => s.StudentId != id).ToList();
                BindGrid();
            }
        }
    }
}

