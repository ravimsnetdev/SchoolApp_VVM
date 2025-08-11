using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolAppUI
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var selecetdStdId = Convert.ToInt32(Session["SelectedStudentId"]);

                var selecetdStudent = Students.Where(x => x.ID == selecetdStdId).FirstOrDefault();

                if (selecetdStudent != null)
                {
                    txtEditName.Text = selecetdStudent.Name;
                    txtEditRoll.Text = selecetdStudent.RollNo;
                    txtEditClass.Text = selecetdStudent.Class;
                    txtEditSection.Text = selecetdStudent.Section;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["SelectedStudentId"]);
            var student = Students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                student.Name = txtEditName.Text;
                student.RollNo = txtEditRoll.Text;
                student.Class = txtEditClass.Text;
                student.Section = txtEditSection.Text;
            }

            Response.Redirect("StudentSummary.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSummary.aspx");
        }

        private List<Student> Students
        {
            get
            {
                if (Session["Students"] == null)
                {
                    Session["Students"] = new List<Student>
            {
                new Student { ID = 1, Name = "Ravinder Reddy Seelam", RollNo = "100", Class = "12", Section = "A" },
                new Student { ID = 2, Name = "John Doe", RollNo = "101", Class = "10", Section = "A" },
                new Student { ID = 3, Name = "Alice Smith", RollNo = "102", Class = "10", Section = "B" }
            };
                }
                return (List<Student>)Session["Students"];
            }
            set { Session["Students"] = value; }
        }
    }
}