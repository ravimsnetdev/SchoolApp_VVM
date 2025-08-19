using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;
using SchoolAppCommon.ViewModels;

namespace SchoolAppUI
{
    public partial class StudentSummary : System.Web.UI.Page
    {
        private readonly string apiBaseUrl;

        public StudentSummary()
        {
            apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await BindGridAsync();
            }
        }

        private async Task BindGridAsync()
        {
            var listStudents = new List<Student_VM>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    listStudents = JsonConvert.DeserializeObject<List<Student_VM>>(json);
                }
            }

            gvStudents.DataSource = listStudents;
            gvStudents.DataBind();
        }

        protected async void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                Session["SelectedStudentId"] = id;
                Response.Redirect("StudentDetails.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if (e.CommandName == "ShowDeletePopup")
            {
                // Store ID in hidden field
                hfDeleteId.Value = id.ToString();

                // Trigger the Bootstrap modal from server-side
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showDeleteModal", @"var myModal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));myModal.show();", true);
            }
        }

        protected async void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfDeleteId.Value);
            string apiUrl = $"{apiBaseUrl}/{id}";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    await BindGridAsync();
                }
                else
                {
                    Response.Write("<script>alert('Error deleting student!');</script>");
                }
            }
        }



        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Session["SelectedStudentId"] = 0;
            Response.Redirect("StudentDetails.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
