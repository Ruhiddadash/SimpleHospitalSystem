using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DashboardDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["doctor"] == null)
                Response.Redirect("Login.aspx");
            else
            Lbl_account.Text = Session["doctor"].ToString();
        }

        protected void Btn_update_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void Btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPassient.aspx");
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}