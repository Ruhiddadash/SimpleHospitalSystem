using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DashboardUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            else
                Lbl_account.Text = Session["user"].ToString();
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Btn_Apointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("Appoinment.aspx");
        }

        protected void Btn_doctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Doctor.aspx");
        }
    }
}