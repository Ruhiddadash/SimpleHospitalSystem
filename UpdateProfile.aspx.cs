using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        readonly NpgsqlConnection con = new NpgsqlConnection("server = localHost; port = 5432; Database = hospital; user ID = postgres; password = ruhid2705");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["doctor"] == null)
                Response.Redirect("Login.aspx");

            Lbl_account.Text = Session["doctor"].ToString();
        }

        protected void Btn_add_Click(object sender, EventArgs e)
        {
            if (Image_upload.HasFile)
            {
                string username = Session["doctor"].ToString();
                string imagePath = $"{Path.Combine(Server.MapPath("image"), username)}.jpg";
                int length = Image_upload.PostedFile.ContentLength;
                byte[] img = new byte[length];
                Image_upload.PostedFile.InputStream.Read(img, 0, length);
                if (!File.Exists(imagePath))
                {
                    var file = File.Create(imagePath);
                    file.Close();
                }
                File.WriteAllBytes(imagePath, img);

                con.Open();
                string query = "update doctor set email = @email, image = @image,imageext = @imageext, catagory = @catagory, description = @descrip where username  = '" + Lbl_account.Text.Trim() + "'";
                NpgsqlCommand command = new NpgsqlCommand(query, con);
                command.Parameters.AddWithValue("@email", Tb_email.Text.Trim());
                command.Parameters.AddWithValue("@image", username);
                command.Parameters.AddWithValue("@imageext", "jpg");
                command.Parameters.AddWithValue("@catagory", Tb_catagory.Text.Trim());
                command.Parameters.AddWithValue("@descrip", Tb_description.Text.Trim());
                command.ExecuteNonQuery();
                con.Close();
                Lbl_status.Text = "Profile Update";
                Tb_email.Text = "Email";
                Tb_catagory.Text = "Catagory";
                Tb_description.Text = "Description";
            }
            else
            {
                Lbl_status.Text = "Profile doesnt update";
            }

        }

        protected void Btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}