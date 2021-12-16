using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class ViewPassient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["doctor"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                Lbl_account.Text = Session["doctor"].ToString();
                Fill();
            }
            
        }
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");

        private void Fill()
        {
            con.Open();
            string query = "select id,passient,doctor,date from appoin where doctor= '" + Lbl_account.Text + "' order by id";
            NpgsqlCommand command = new NpgsqlCommand(query, con);
            NpgsqlDataReader ndr = command.ExecuteReader();
            GridView_appoint.DataSource = ndr;
            GridView_appoint.DataBind();
            con.Close();
        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Tb_id.Text.Trim());
            string query = "delete from appoin where id = " +id + "";
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
            Fill();
        }
    }
}