using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class AddFeedback : System.Web.UI.Page
    {
        SiteUser s = null;
        Contribution c;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
            if (Session["fdbkSession"] != null)
            {
                c = (Contribution)Session["fdbkSession"];
                if (!IsPostBack)
                {
                    // add details to form
                    lblTitle.Text = c.Title;
                    ddlStatus.Text = c.Status;
                    txtFeedback.Text = c.Feedback;
                }                
            }
            else
            {
                Response.Redirect("~/UI/ViewSubmissions.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string status = ddlStatus.SelectedItem.ToString();
            string feedback = txtFeedback.Text;
            if(DBConnection.UpdateContributionStatus(c, status, feedback))
            {
                lblSubmit.Text = "Feedback submitted.";
            }
            else
            {
                lblSubmit.Text = "Could not submit feedback. Try again later.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewSubmissions.aspx");
        }
    }
}