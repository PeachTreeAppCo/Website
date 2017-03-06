using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class EditCompetition : System.Web.UI.Page
    {
        SiteUser s = null;
        Competition c = new Competition();

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
            if (Session["CompSession"] != null)
            {
                c = (Competition)Session["CompSession"];
                if (!IsPostBack)
                {
                    // add details to form
                    txtTitle.Text = c.Name;
                    calInitClose.VisibleDate = c.InitialClosure1;
                    calInitClose.SelectedDate = c.InitialClosure1;
                    calFinalClose.VisibleDate = c.FinalClosure1;
                    calFinalClose.SelectedDate = c.FinalClosure1;                    
                }                
            }
            else
            {
                Response.Redirect("~/UI/ViewCompetitions.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblUpdate.Text = "";
            if (txtTitle.Text != "")
            {
                if (calInitClose.SelectedDate.Date != DateTime.MinValue)
                {
                    if (calFinalClose.SelectedDate.Date != DateTime.MinValue)
                    {
                        string title = txtTitle.Text;
                        DateTime initClose = calInitClose.SelectedDate.Date;
                        DateTime finalClose = calFinalClose.SelectedDate.Date;
                        if (initClose > DateTime.Now)
                        {
                            if (finalClose > initClose)
                            {
                                bool b = DBConnection.updateCompetition(c, title, initClose, finalClose);
                                if (b)
                                {
                                    lblUpdate.Text = "Competition updated successfully.";
                                }
                                else
                                {
                                    lblUpdate.Text = "Could not update competition.";
                                }
                            }
                            else
                            {
                                lblUpdate.Text = "Final closure date must be after initial closure date.";
                            }
                        }
                        else
                        {
                            lblUpdate.Text = "Both dates must be in the future.";
                        }
                    }
                    else
                    {
                        lblUpdate.Text = "Please select a Final Closure Date.";
                    }
                }
                else
                {
                    lblUpdate.Text = "Please select an Initial Closure Date.";
                }
            }
            else
            {
                lblUpdate.Text = "Please enter a title.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewCompetitions.aspx");
        }
    }
}