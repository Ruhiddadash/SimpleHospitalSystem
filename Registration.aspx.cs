using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");
        protected void Btn_register_Click(object sender, EventArgs e)
        {
            string email = tb_email.Text.Trim();
            string username = tb_username.Text.Trim();
            string password = tb_password.Text;
            string confirmPassword = tb_confirm.Text;

            if (username != "" && password != "" && confirmPassword != "")
            {
                if (password == confirmPassword)
                {
                    if (Cb_doctor.Checked)
                    {
                        con.Open();
                        NpgsqlCommand checkCommand = new NpgsqlCommand("select count(*) from doctor where username = @user", con);
                        checkCommand.Parameters.AddWithValue("@user", username);
                        int userExist = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (userExist == 0)
                        {
                            NpgsqlCommand command = new NpgsqlCommand("insert into doctor (username,password,email) values (@user,@pass,@email)", con);
                            command.Parameters.AddWithValue("@user", username);
                            command.Parameters.AddWithValue("@pass", password);
                            command.Parameters.AddWithValue("@email", email);
                            command.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("Login.aspx");

                        }
                        else
                        {
                            Lbl_status.Text = "Username already exist!";
                            Lbl_status.Visible = true;
                            con.Close();
                        }

                    }
                    else
                    {
                        con.Open();
                        NpgsqlCommand checkCommand = new NpgsqlCommand("select count(*) from users where username = @user", con);
                        checkCommand.Parameters.AddWithValue("@user", username);
                        int userExist = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (userExist == 0)
                        {
                            NpgsqlCommand command = new NpgsqlCommand("insert into users (username,password,email) values (@user,@pass,@email)", con);
                            command.Parameters.AddWithValue("@user", username);
                            command.Parameters.AddWithValue("@pass", password);
                            command.Parameters.AddWithValue("@email", email);
                            command.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("Login.aspx");


                        }
                        else
                        {
                            Lbl_status.Text = "Username already exist!";
                            Lbl_status.Visible = true;
                            con.Close();
                        }
                    }

                }
                else
                {
                    Lbl_status.Text = "Passwords dont match!";
                    Lbl_status.Visible = true;
                }
            }
            else if (username == "" || password == "" || confirmPassword == "")
            {
                Lbl_status.Text = "Fill the gap!";
                Lbl_status.Visible = true;
            }
        }

        protected void lbtn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}