using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                    txtEditName.Text = selecetdStudent.Name;
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
                student.Name = txtEditName.Text;
                student.RollNumber = txtEditRoll.Text;
                student.Class = txtEditClass.Text;
                student.Section = txtEditSection.Text;
            }

            Response.Redirect("StudentSummary.aspx");
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