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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
                switch (s.UserType1)
                {
                    // Student
                    case "Student":
                        s = new Student(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID);
                        break;
                    // Marketing Coordinator
                    case "Marketing Coordinator":
                        s = new MarketingCoordinator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID);
                        break;
                    // Marketing Manager
                    case "Marketing Manager":
                        s = new MarketingManager(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID);
                        break;
                    // Administrator
                    case "Administrator":
                        s = new Administrator(s.UserID1, s.GivenName1, s.Surname1, s.UserType1, s.Email1, s.Password1, s.MobileNumber1, s.GenderID, s.FacultyID);
                        break;
                    default:
                        Session.Clear();
                        Response.Redirect("~/UI/Default.aspx");
                        break;
                }
                setupPageForUser(s);
                lblWelcome.Text = "Welcome, " + s.GivenName1 + "!";
            }
            else if (Session["FacultySession"] != null)
            {
                f = (FacultyUser)Session["FacultySession"];
                lblWelcome.Text = "Welcome, " + f.FacultyName1 + " guest!";
                setupPageForGuest();
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

        public void btnAddContribution_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AddContribution.aspx");
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
        
        public void setupPageForUser(SiteUser s)
        {
            switch (s.UserType1)
            {
                // Student
                case "Student":
                    btnAddContribution.Visible = true;
                    btnViewContributions.Visible = true;
                    btnViewReports.Visible = true;
                    btnAccountSettings.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    break;
                // Marketing Coordinator
                case "Marketing Coordinator":
                    btnAddContribution.Visible = false;
                    btnViewContributions.Visible = true;
                    btnViewReports.Visible = true;
                    btnAccountSettings.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    break;
                // Marketing Manager
                case "Marketing Manager":
                    btnAddContribution.Visible = false;
                    btnViewContributions.Visible = true;
                    btnViewReports.Visible = true;
                    btnAccountSettings.Visible = true;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    break;
                // Administrator
                case "Administrator":
                    btnAddContribution.Visible = false;
                    btnViewContributions.Visible = false;
                    btnViewReports.Visible = false;
                    btnAccountSettings.Visible = false;
                    btnViewPublications.Visible = true;
                    btnViewFailedLogins.Visible = true;
                    btnManageUsers.Visible = true;
                    break;
                default:
                    btnAddContribution.Visible = false;
                    btnViewContributions.Visible = false;
                    btnViewReports.Visible = false;
                    btnAccountSettings.Visible = false;
                    btnViewPublications.Visible = false;
                    btnViewFailedLogins.Visible = false;
                    btnManageUsers.Visible = false;
                    break;
            }
        }    

        public void setupPageForGuest()
        {
            btnAddContribution.Visible = false;
            btnViewContributions.Visible = true;
            btnViewReports.Visible = true;
            btnAccountSettings.Visible = false;
            btnViewPublications.Visible = true;
            btnViewFailedLogins.Visible = false;
            btnManageUsers.Visible = false;
        }
    }
}