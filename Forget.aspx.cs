using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class Forget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_code.Visible = false;
            tb_new.Visible = false;
            Btn_sumbit.Visible = Btn_reset.Visible = false;
        }
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");
        Random r = new Random();
        private int RecoveryCode()
        {
            return r.Next(10000, 99999);
        }
        string email = "";
        private bool SendEmail()
        {
            try
            {
                string to = tb_email.Text.Trim();
                email = to;
                string from = "ruhiddadash@gmail.com";
                string pass = "elcin637";

                int code = RecoveryCode();

                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(to));
                mm.From = new MailAddress(from, "Team Aboubakan");
                mm.Subject = "Reset your password";
                mm.IsBodyHtml = true;
                mm.Body = "Your reset code: <b>" + code + "</b>";

                NetworkCredential nc = new NetworkCredential();
                nc.UserName = from;
                nc.Password = pass;

                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nc;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Send(mm);

                WriteCodeToDatabes(code);

                return true;

            }
            catch
            {
                return false;
            }
        }


        private void WriteCodeToDatabes(int code)
        {
            try
            {

                NpgsqlCommand command = new NpgsqlCommand("insert into reset (email,code) values (@email,@code)", con);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@code", code);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }

        }
        protected void Btn_reset_Click(object sender, EventArgs e)
        {
            if (Cb_doctor.Checked)
            {
                string password = tb_new.Text;
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("update doctor set password = @pass where email = @email", con);
                command.Parameters.AddWithValue("@pass", password);
                command.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                command.ExecuteNonQuery();
                Response.Write("Password succesfully changed");
                Response.Redirect("Login.aspx");
            }
            else
            {
                string password = tb_new.Text;
                con.Open();
                NpgsqlCommand command = new NpgsqlCommand("update users set password = @pass where email = @email", con);
                command.Parameters.AddWithValue("@pass", password);
                command.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                command.ExecuteNonQuery();
                Response.Write("Password succesfully changed");
                Response.Redirect("Login.aspx");
            }
        }

        protected void Btn_send_Click(object sender, EventArgs e)
        {

            if (Cb_doctor.Checked)
            {
                if (tb_email.Text != "")
                {
                    con.Open();
                    NpgsqlCommand checkCommand = new NpgsqlCommand("select count(*) from doctor where email = @email", con);
                    checkCommand.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                    int userExist = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (userExist == 1)
                    {
                        if (SendEmail())
                        {
                            tb_code.Visible = Btn_sumbit.Visible = true;
                            Response.Write("Mail is sent your email");
                            Btn_send.Visible = false;
                            con.Close();
                        }
                        else
                        {
                            Response.Write("Recovery mail dosnt send");
                            con.Close();
                        }

                    }
                    else
                    {
                        Response.Write("This email doesnt exist out site!");
                        con.Close();
                    }

                }
                else
                {
                    Response.Write("Write your email!");

                }
            }
            else
            {
                if (tb_email.Text != "")
                {
                    con.Open();
                    NpgsqlCommand checkCommand = new NpgsqlCommand("select count(*) from users where email = @email", con);
                    checkCommand.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                    int userExist = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (userExist == 1)
                    {
                        if (SendEmail())
                        {
                            tb_code.Visible = Btn_sumbit.Visible = true;
                            Response.Write("Mail is sent your email");
                            Btn_send.Visible = false;
                            con.Close();
                        }
                        else
                        {
                            Response.Write("Recovery mail dosnt send");
                            con.Close();
                        }

                    }
                    else
                    {
                        Response.Write("This email doesnt exist out site!");
                        con.Close();
                    }

                }
                else
                {
                    Response.Write("Write your email!");

                }
            }
        }

        protected void Btn_sumbit_Click(object sender, EventArgs e)
        {
            string code = tb_code.Text.Trim();
            string mail = tb_email.Text.Trim();
            con.Open();
            try
            {
                NpgsqlCommand checkCommand = new NpgsqlCommand("select count(*) from reset where email = '" + mail + "' and code = " + code + " and time > current_timestamp - interval '10 minute'", con);
                //checkCommand.Parameters.AddWithValue("@email", mail);
                //checkCommand.Parameters.AddWithValue("@code", code);
                var res = checkCommand.ExecuteScalar();
                int count = Convert.ToInt32(res);
                if (count > 0)
                {
                    tb_new.Visible = Btn_reset.Visible = true;
                    Response.Write("Your recovery code is correct");
                    con.Close();
                }
                else
                {
                    Response.Write("Your recovery code is wrong !");
                    con.Close();
                    tb_code.Visible = true;
                    Btn_sumbit.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }
    }
}