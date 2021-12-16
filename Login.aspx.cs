using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("DashboardUser.aspx");
            else if (Session["doctor"] != null)
                Response.Redirect("DashboardDoctor.aspx");
               
        }
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");

        protected void Btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text;

            if (Cb_doctor.Checked)
            {
                con.Open();
                string query = "select * from doctor where username = @username AND password = @password;";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                int id = Convert.ToInt32(command.ExecuteScalar());
                if (id > 0)
                {
                    Session["doctor"] = username;
                    Response.Redirect("DashboardDoctor.aspx");
                    con.Close();
                }
                else
                {
                    Lbl_status.Text = "Login or Password is wrong!";
                    Lbl_status.Visible = true;
                    con.Close();
                }
            }
            else
            {
                con.Open();
                string query = "select * from users where username = @username AND password = @password;";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                int id = Convert.ToInt32(command.ExecuteScalar());
                if (id > 0)
                {
                    Session["user"] = username;
                    Response.Redirect("DashboardUser.aspx");
                    con.Close();
                }
                else
                {
                    Lbl_status.Text = "Login or Password is wrong!";
                    Lbl_status.Visible = true;
                    con.Close();
                }
            }

        }

        protected void lbtn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void lbtn_forget_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forget.aspx");
        }
    }
}