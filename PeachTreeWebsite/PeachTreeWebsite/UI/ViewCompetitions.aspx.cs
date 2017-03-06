using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ViewCompetitions : System.Web.UI.Page
    {
        SiteUser s = new SiteUser();
        List<Competition> competitions = new List<Competition>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
                competitions = DBConnection.getCompetitons();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            int id = int.Parse(row.Cells[0].Text);
            Competition c = (from comp in competitions
                             where comp.ID1 == id
                             select comp).First();

            if (e.CommandName == "EditComp")
            {
                Session["compSession"] = c;
                Response.Redirect("~/UI/EditCompetition.aspx");
            }
            if (e.CommandName == "DeleteComp")
            {
                DBConnection.deleteCompetition(c);
            }
        }

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AddCompetition.aspx");
        }
    }
}