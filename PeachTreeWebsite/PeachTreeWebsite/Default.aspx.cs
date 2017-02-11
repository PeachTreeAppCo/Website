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
        // Bullshit code
        string[] usernames = { "Tom", "Dick", "Harry" };
        string[] passwords = { "tom1", "dick1", "harry1" };
        // End bullshit code

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //User loggedInUser = DBConnection.login(Login1.UserName, Login1.Password);

            //if (loggedInUser.UserName1 != "")
            //{
            //    Session["user"] = loggedInUser;
            //    Response.Redirect("~/Home.aspx");
            //}

            // Bullshit code
            //if (usernames.Contains(Login1.UserName) && passwords.Contains(Login1.Password))
            //{
            //    Session["user"] = new User();
            //    Response.Redirect("~/Home.aspx");
            //}
            // End bullshit code
        }
    }
}