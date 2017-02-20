using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        List<SiteUser> users = new List<SiteUser>();
        List<UserType> userTypes = new List<UserType>();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<UserType> userTypes = DBConnection.getUserTypes();
            foreach(UserType u in userTypes)
            {
                ddlTypeofUser.Items.Add(u.UserTypeName1);
            }
        }

        protected void ddlTypeofUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate listbox with user's emails
            lbUsers.Items.Clear();
            // Use LINQ to select the type id from the selected value
            UserType u = (UserType)from type in userTypes
                                   where type.UserTypeName1 == ddlTypeofUser.SelectedItem.ToString()
                                   select type;
            //users = DBConnection.getUsersByType(u.UserTypeID1);
            foreach(SiteUser s in users)
            {
                lbUsers.Items.Add(s.Email1);
            }
        }

        protected void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate form with user details
            // Use LINQ to select the user from the selected email
            SiteUser s = (SiteUser)from user in users
                                   where user.Email1 == lbUsers.SelectedItem.ToString()
                                   select user;

            // Populate form with user data
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update User in DB

        }
    }
}