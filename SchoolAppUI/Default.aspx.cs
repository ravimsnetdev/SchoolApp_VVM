using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolAppUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardMetrics();
            }
        }

        private void LoadDashboardMetrics()
        {
            // ✅ Hard-coded demo data (replace with DB/API calls later)
            int totalStudents = 500;
            int totalTeachers = 40;
            int presentStudents = 460;
            int absentStudents = totalStudents - presentStudents;

            lblStudentsCount.Text = totalStudents.ToString();
            lblTeachersCount.Text = totalTeachers.ToString();
            lblPresentStudents.Text = presentStudents.ToString();
            lblAbsentStudents.Text = absentStudents.ToString();
        }
    }
}