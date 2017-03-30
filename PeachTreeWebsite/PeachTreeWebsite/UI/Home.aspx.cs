using PeachTreeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeachTreeWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        SiteUser s = new SiteUser();
        FacultyUser f = new FacultyUser();
        Guest g = new Guest();
        string[] vowels = new string[] { "A", "E", "I", "O", "U"};

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
                switch (s.UserType1)
                {
                    // Student
                    case "Student":
                        s = new Student(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID, s.LastLogin);
                        break;
                    // Marketing Coordinator
                    case "Marketing Coordinator":
                        s = new MarketingCoordinator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID, s.LastLogin);
                        break;
                    // Marketing Manager
                    case "Marketing Manager":
                        s = new MarketingManager(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID, s.LastLogin);
                        break;
                    // Administrator
                    case "Administrator":
                        s = new Administrator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID, s.LastLogin);
                        break;
                    default:
                        Session.Clear();
                        Response.Redirect("~/UI/Default.aspx");
                        break;
                }
                setupPageForUser(s);
                lblWelcome.Text = "Welcome, " + s.GivenName1 + "!";
                if (vowels.Contains(s.UserType1[0].ToString()))
                {
                    lblUserType.Text = "You are logged in as an " + s.UserType1;
                }
                else
                {
                    lblUserType.Text = "You are logged in as a " + s.UserType1;
                }
                if (s.LastLogin != DateTime.MinValue)
                {
                    lblLastLogin.Text = "Last logged in: " + s.LastLogin;
                }
            }
            else if (Session["FacultySession"] != null)
            {
                f = (FacultyUser)Session["FacultySession"];
                lblWelcome.Text = "Welcome, " + f.FacultyName1 + " guest!";
                setupPageForFacultyGuest();
            }
            else if (Session["GuestSession"] != null)
            {
                lblWelcome.Text = "Welcome, Guest!";
                setupPageForGuest();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
        }

        public void btnViewContributions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewContributions.aspx");
        }

        public void btnViewReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewReports.aspx");
        }

        public void btnAccountSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountSettings.aspx");
        }

        public void btnViewPublications_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewPublications.aspx");
        }

        public void btnViewFailedLogins_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewFailedLoginAttempts.aspx");
        }        

        public void btnManageUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ManageUsers.aspx");
        }
        public void btnViewCompetitions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewCompetitions.aspx");
        }

        public void btnViewSubmissions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewSubmissions.aspx");
        }        

        public void setupPageForUser(SiteUser s)
        {
            switch (s.UserType1)
            {
                // Student
                case "Student":
                    btnViewContributions.Visible = true;
                    btnViewSubmissions.Visible = false;
                    btnViewReports.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    btnViewCompetitions.Visible = false;
                    break;
                // Marketing Coordinator
                case "Marketing Coordinator":
                    btnViewContributions.Visible = false;
                    btnViewSubmissions.Visible = true;
                    btnViewReports.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    btnViewCompetitions.Visible = false;
                    break;
                // Marketing Manager
                case "Marketing Manager":
                    btnViewContributions.Visible = false;
                    btnViewSubmissions.Visible = false;
                    btnViewReports.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    btnViewCompetitions.Visible = false;
                    break;
                // Administrator
                case "Administrator":
                    btnViewContributions.Visible = false;
                    btnViewSubmissions.Visible = false;
                    btnViewReports.Visible = false;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = true;
                    btnManageUsers.Visible = false;
                    btnViewCompetitions.Visible = true;
                    break;
                default:
                    btnViewContributions.Visible = false;
                    btnViewSubmissions.Visible = false;
                    btnViewReports.Visible = false;
                    btnViewPublications.Visible = false;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    btnViewCompetitions.Visible = false;
                    break;
            }
        }    

        public void setupPageForGuest()
        {
            btnViewContributions.Visible = false;
            btnViewSubmissions.Visible = false;
            btnViewReports.Visible = false;
            btnViewPublications.Visible = true;
            btnViewFailedLogins.Visible = false;
            btnManageUsers.Visible = false;
            btnViewCompetitions.Visible = false;
        }

        public void setupPageForFacultyGuest()
        {
            btnViewContributions.Visible = false;
            btnViewSubmissions.Visible = false;
            btnViewReports.Visible = true;
            btnViewPublications.Visible = true;
            btnViewFailedLogins.Visible = false;
            btnManageUsers.Visible = false;
            btnViewCompetitions.Visible = false;
        }
    }
}