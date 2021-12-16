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
    public partial class Doctor : System.Web.UI.Page
    {
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");

        protected void Page_Load(object sender, EventArgs e)
        {
            Fill();
            Lbl_account.Text = Session["user"].ToString();

        }
        private void Fill() {
            NpgsqlDataAdapter ndb = new NpgsqlDataAdapter("select image,imageext,username,description,catagory from doctor", con);
            DataTable dt = new DataTable();
            ndb.Fill(dt);
            ListView_doctor.DataSource = dt;
            ListView_doctor.DataBind(); 
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Img_search_Click(object sender, ImageClickEventArgs e)
        {
            string catagory = Tb_search.Text.Trim();
            string query = "select image,imageext,username,description,catagory from doctor where catagory = '" + catagory + "' order by id";
            NpgsqlDataAdapter ndb = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ndb.Fill(dt);
            ListView_doctor.DataSource = dt;
            ListView_doctor.DataBind();
        }
    }
}