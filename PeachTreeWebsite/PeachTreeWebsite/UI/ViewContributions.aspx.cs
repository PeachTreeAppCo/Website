using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ViewContributions : System.Web.UI.Page
    {
		List<Contribution> contributions = new List<Contribution>();
		List<Competition> competitions = new List<Competition>();
		SiteUser s = new SiteUser();

		protected void Page_Load(object sender, EventArgs e)
        {
			if (Session["UserSession"] != null)
			{
				s = (SiteUser)Session["UserSession"];
				contributions = DBConnection.getContributionsForUser(s.UserID1);
				competitions = DBConnection.getCompetitons();
				// Populate table with contributions, displaying title, file, image, closure dates, comp name and edit/delete buttons

			}
			else
			{
				Session.Clear();
				Response.Redirect("~/UI/Default.aspx");
			}
        }
    }
}