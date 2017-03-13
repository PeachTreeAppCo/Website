using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ViewReports : System.Web.UI.Page
    {
        List<Competition> competitions = new List<Competition>();
        FacultyUser f = null;
        SiteUser s = null;
        int facultyID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
                facultyID = s.FacultyID;
            }
            else if (Session["FacultySession"] != null)
            {
                f = (FacultyUser)Session["FacultySession"];
                facultyID = f.FacultyID1;
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
            competitions = DBConnection.getCompetitons();

            if (!IsPostBack)
            {
                ddlComps.Items.Clear();
                foreach (Competition c in competitions)
                {
                    ddlComps.Items.Add(c.Name);
                }
                ddlComps.SelectedIndex = 0;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlComps.SelectedItem != null)
            {
                string selectedComp = ddlComps.SelectedItem.ToString();
                int compID = (from com in competitions
                              where com.Name == selectedComp
                              select com.ID1).First();
                // Populate results
                lblContribTotal.Text = DBConnection.report_getTotalContributions(compID);
                lblContribFaculty.Text = DBConnection.report_getContributionsForFaculty(compID, facultyID);
                lblContributors.Text = DBConnection.report_getCountContributors(compID, facultyID);

                if(s != null && s.UserType1 == "Marketing Manager")
                {
                    lblNoCommentsResult.Text = DBConnection.report_getContributionsNoResponse();
                    lblNoComments14DaysResult.Text = DBConnection.report_getContributionsNoResponse14Days();
                }
            }
            else
            {
                lblErr.Text = "Select a year";
            }
        }
    }
}