using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeachTreeWebsite
{
    public partial class LoggedIn : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/UI/Default.aspx");
        }        
    }
}