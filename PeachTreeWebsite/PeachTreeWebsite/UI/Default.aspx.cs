using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null || Session["FacultySession"] != null || Session["GuestSession"] != null)
            {
                Response.Redirect("~/UI/Home.aspx");
            }
            List<string> faculties = DBConnection.getFaculties();
            if (faculties != null)
            {
                foreach (string s in faculties)
                {
                    ddlFaculty.Items.Add(s);
                }
            }            
            ddlFaculty.Attributes["style"] = "width=30%; max-width: 280px";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SiteUser s = null;
            try
            {
                s = DBConnection.login(txtEmail.Text, txtPwd.Text);
                DBConnection.UpdateLoginTime(s.UserID1);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                lblLoginError.Text = "Error logging in.";
            }
            if (s != null)
            {
                Session["UserSession"] = s;
                Response.Redirect("~/UI/Home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblLoginError.Text = "User not found. Please check your details and try again.";
                DBConnection.AddFailedLogin(txtEmail.Text, txtPwd.Text);
            }
        }

        protected void btnFacultySignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string facultyName = ddlFaculty.SelectedItem.ToString();
                string facultyPwd = txtFacultyPwd.Text;
                FacultyUser f = DBConnection.facultyLogin(facultyName, facultyPwd);
                if (f != null)
                {
                    Session["FacultySession"] = f;
                    Response.Redirect("~/UI/Home.aspx");
                }
                else
                {
                    lblFacultyLoginErr.Text = "Error logging in.";
                }
            }
            catch (Exception)
            {
                lblFacultyLoginErr.Text = "Error logging in.";
            }
        }

        protected void btnGuestSignIn_Click(object sender, EventArgs e)
        {
            Session["GuestSession"] = new Guest();
            Response.Redirect("~/UI/Home.aspx");
        }
    }
}