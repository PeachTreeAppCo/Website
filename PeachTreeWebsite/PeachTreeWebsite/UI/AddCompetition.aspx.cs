using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeachTreeWebsite.UI
{
    public partial class AddCompetition : System.Web.UI.Page
    {
        SiteUser s = null;
        int uploadedCompID;

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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSaveError.Text = "";
            if (txtTitle.Text != "")
            {                
                if(calInitClose.SelectedDate.Date != DateTime.MinValue)
                {                    
                    if (calFinalClose.SelectedDate.Date != DateTime.MinValue)
                    {
                        string title = txtTitle.Text;
                        DateTime initClose = calInitClose.SelectedDate.Date;
                        DateTime finalClose = calFinalClose.SelectedDate.Date;
                        if(initClose > DateTime.Now)
                        {
                            if (finalClose > initClose)
                            {
                                uploadedCompID = DBConnection.addCompetition(title, initClose, finalClose);
                                if (uploadedCompID != -1)
                                {
                                    lblSaveError.Text = "Competition added successfully.";
                                }
                                else
                                {
                                    lblSaveError.Text = "Could not add competition.";
                                }
                            }
                            else
                            {
                                lblSaveError.Text = "Final closure date must be after initial closure date.";
                            }
                        }
                        else
                        {
                            lblSaveError.Text = "Both dates must be in the future.";
                        }
                    }
                    else
                    {
                        lblSaveError.Text = "Please select a Final Closure Date.";
                    }
                }
                else
                {
                    lblSaveError.Text = "Please select an Initial Closure Date.";
                }
            }
            else
            {
                lblSaveError.Text = "Please enter a title.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewCompetitions.aspx");
        }
    }
}