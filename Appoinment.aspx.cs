using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class Appoinment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                Lbl_account.Text = Session["user"].ToString();
                Tb_username.Text = Session["user"].ToString();
                if (!IsPostBack)
                {
                    Fill();
                    List();
                    Calendar.Visible = false;
                }
            }

        }
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");
        private void List()
        {
            con.Open();
            string com = "Select * from doctor";
            NpgsqlDataAdapter adpt = new NpgsqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataBind();
            Ddl_doctor.DataTextField = "username";
            Ddl_doctor.DataValueField = "username";
            Ddl_doctor.DataBind();
            con.Close();
        }
        private void Fill()
        {
            con.Open();
            string query = "select passient,doctor,date from appoin where passient= '" + Lbl_account.Text + "' order by id";
            NpgsqlCommand command = new NpgsqlCommand(query, con);
            NpgsqlDataReader ndr = command.ExecuteReader();
            GridView_appoint.DataSource = ndr;
            GridView_appoint.DataBind();
            con.Close();
        }

        protected void Btn_appoint_Click(object sender, EventArgs e)
        {
            string selectedUser = Ddl_doctor.SelectedItem.Value;
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert into appoin(passient,doctor,date) values (@passient,@doctor,@date)", con);
            command.Parameters.AddWithValue("@passient", Tb_username.Text.Trim());
            command.Parameters.AddWithValue("@doctor", selectedUser);
            command.Parameters.AddWithValue("@date", Tb_date.Text.Trim());
            command.ExecuteNonQuery();
            con.Close();
            Fill();
        }



        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            var dt = DateTime.Today;
            var sc = Calendar.SelectedDate;
            if (sc >= dt)
            {
                Tb_date.Text = Calendar.SelectedDate.ToString("dd/MM/yyyy");
                Calendar.Visible = false;
            }
            else
            {
                Tb_date.Text = "Wrong Date";
                Calendar.Visible = false;
            }

        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Transparent;
            }
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Image_btn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar.Visible)
            {
                Calendar.Visible = false;
            }
            else
            {
                Calendar.Visible = true;
            }
            Calendar.Attributes.Add("style", "position:absolute");
        }

    }
}