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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SiteUser"] == null && Session["FacultySession"] == null && Session["GuestSession"] == null)
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
        }
    }
}