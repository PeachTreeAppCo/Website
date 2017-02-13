using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeachTreeWebsite
{
    public partial class _Default : Page
    {
        List<string> faculties = new List<string>(new string[] {
            "Architecture, Computing & Humanities",
            "Business School",
            "Education & Health",
            "Engineering & Science"});
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SiteUser"] != null)
            {
                Response.Redirect("~/UI/Home.aspx");
            }
            foreach (string s in faculties)
            {
                ddlFaculty.Items.Add(s);
            }            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool b = User.Identity.IsAuthenticated;
            Response.Redirect("~/UI/Home.aspx");
            //string email = txtEmail.Text;
            //string pwd = txtPwd.Text;
            //SiteUser s = DBConnection.login(email, pwd);
        }
    }
}