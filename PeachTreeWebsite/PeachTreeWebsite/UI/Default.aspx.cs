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
        List<string> faculties = new List<string>(new string[] {
            "Architecture, Computing & Humanities",
            "Business School",
            "Education & Health",
            "Engineering & Science"});
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SiteUser"] != null || Session["FacultySession"] != null || Session["GuestSession"] != null)
            {
                Response.Redirect("~/UI/Home.aspx");
            }
            foreach (string s in faculties)
            {
                ddlFaculty.Items.Add(s);
            }
            ddlFaculty.Attributes["style"] = "width=30%; max-width: 280px";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pwd = txtPwd.Text;
                SiteUser s = DBConnection.login(email, pwd);
                if (s != null)
                {
                    switch (s.UserType1)
                    {
                        // Student
                        case 1:
                            s = new Student(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.StudyYear1);
                            break;
                        // Marketing Coordinator
                        case 2:
                            s = new MarketingCoordinator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.StudyYear1);
                            break;
                        // Marketing Manager
                        case 3:
                            s = new MarketingManager(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.StudyYear1);
                            break;
                        // Administrator
                        case 4:
                            s = new Administrator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.StudyYear1);
                            break;
                        default:
                            break;
                    }
                    Session["UserSession"] = s;
                    Response.Redirect("~/UI/Home.aspx");
                }
                else
                {
                    lblLoginError.Text = "Error logging in.";
                }
            }
            catch (Exception)
            {
                lblLoginError.Text = "Error logging in.";
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