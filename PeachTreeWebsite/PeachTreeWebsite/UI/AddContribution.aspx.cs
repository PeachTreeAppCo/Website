using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeachTreeWebsite.UI
{
    public partial class AddContribution : System.Web.UI.Page
    {
        SiteUser s = null;

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = fileContrib.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = "";
            string title = txtTitle.Text;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
            }
            if (contenttype != "")
            {
                Stream fs = fileContrib.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                DBConnection.UploadFile(title, bytes, s.UserID1);               
            }
            else
            {
                lblSubmit.Text = "File type must be .doc or .docx";
            }
        }

        protected void btnTnC_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", 
                "<script>alert('This is the terms and conditions. Accept them or else!')</script>"
                );
        }
    }
}