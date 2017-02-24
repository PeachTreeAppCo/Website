using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class AddContribution : System.Web.UI.Page
    {
        SiteUser s = null;
        bool badImg = false;
        List<Competition> competitions = new List<Competition>();

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
            competitions = DBConnection.getCompetitons();
            foreach(Competition c in competitions)
            {
                if(DateTime.Now < c.InitialClosure1)
                {
                    ddlComps.Items.Add(c.Name);
                }                
            }
            ddlComps.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Clear previous errors
            lblSubmit.Text = "";

            if (cbTerms.Checked)
            {
                if (txtTitle.Text != "")
                {
                    string title = txtTitle.Text;
                    byte[] docBytes = null;
                    byte[] imgBytes = null;
                    int compID = (from c in competitions
                                  where c.Name == ddlComps.SelectedItem.Text
                                  select c.ID1).First();                                                

                    // check for files and convert to byte array
                    if (fileContrib.HasFile)
                    {
                        docBytes = convertDocToByte();
                        if (fileImage.HasFile)
                        {
                            imgBytes = convertImageToByte();
                        }
                    }                    

                    // Check if docs exist and upload appropriately
                    if (docBytes != null && imgBytes != null)
                    {
                        if(DBConnection.UploadFileWithImg(title, docBytes, imgBytes, s.UserID1, compID))
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution and image uploaded successfully!";
                        }
                        else
                        {
                            lblSubmit.Text = "Error uploading files. Please try again later.";
                        }
                    }
                    else if (docBytes != null && !badImg)
                    {
                        if(DBConnection.UploadFile(title, docBytes, s.UserID1, compID))
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution uploaded successfully!";
                        }
                        else
                        {
                            lblSubmit.Text = "Error uploading files. Please try again later.";
                        }
                    }
                    else if (docBytes != null && badImg)
                    {
                        lblSubmit.Text = "Please ensure image is a .png file.";
                    }
                    else
                    {
                        lblSubmit.Text = "Please select a valid file (.doc / .docx) to upload for your contribution.";
                    }
                }
                else
                {
                    lblSubmit.Text = "Please select a title";
                }
            }
            else
            {
                lblSubmit.Text = "You must accept the terms & conditions";
            }
        }

        protected void btnTnC_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts",
                "<script>alert('This is the terms and conditions. Accept them or else!')</script>"
                );
        }

        private byte[] convertDocToByte()
        {
            string filePath = fileContrib.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = "";

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
                return bytes;
            }
            else
            {
                return null;
            }
        }

        private byte[] convertImageToByte()
        {
            string filePath = fileImage.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = "";

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".png":
                    contenttype = "image/png";
                    break;
            }

            if (contenttype != "")
            {
                Stream fs = fileImage.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                return bytes;
            }
            else
            {
                badImg = true;
                return null;
            }
        }
    }
}