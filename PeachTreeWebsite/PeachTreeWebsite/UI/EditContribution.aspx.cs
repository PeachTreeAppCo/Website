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
    public partial class EditContribution : System.Web.UI.Page
    {
        SiteUser s = null;
        Contribution c;
        bool badImg = false;

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
            if (Session["ContSession"] != null)
            {
                c = (Contribution)Session["ContSession"];
                // add details to form
                txtTitle.Text = c.Title;
            }
            else
            {                
                Response.Redirect("~/ViewContributions.aspx");
            }
        }

        protected void btnTnC_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/TermsAndConditions.aspx");
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
                    string filecontenttype = "";

                    // check for files and convert to byte array
                    if (fileContrib.HasFile)
                    {
                        // Get file details
                        string filePath = fileContrib.PostedFile.FileName;
                        string filename = Path.GetFileName(filePath);
                        string fileext = Path.GetExtension(filename);

                        //Set the contenttype based on File Extension
                        switch (fileext)
                        {
                            case ".doc":
                                filecontenttype = "application/vnd.ms-word";
                                break;
                            case ".docx":
                                filecontenttype = "application/vnd.ms-word";
                                break;
                        }
                        if (filecontenttype != "")
                        {
                            Stream fs = fileContrib.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            docBytes = br.ReadBytes((Int32)fs.Length);
                        }

                        if (fileImage.HasFile)
                        {
                            // get image details
                            string imgPath = fileImage.PostedFile.FileName;
                            string imgname = Path.GetFileName(imgPath);
                            string imgext = Path.GetExtension(imgname);
                            string imgcontenttype = "";

                            //Set the contenttype based on File Extension
                            switch (imgext)
                            {
                                case ".png":
                                    imgcontenttype = "image/png";
                                    break;
                            }

                            if (imgcontenttype != "")
                            {
                                Stream fs = fileImage.PostedFile.InputStream;
                                BinaryReader br = new BinaryReader(fs);
                                imgBytes = br.ReadBytes((Int32)fs.Length);
                            }
                        }
                    }

                    // Check if docs exist and upload appropriately
                    if (docBytes != null && imgBytes != null)
                    {
                        if (DBConnection.UpdateContributionWithImg(c, title, fileContrib.FileName, filecontenttype, docBytes, fileImage.FileName, imgBytes))
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution and image updated successfully!";
                        }
                        else
                        {
                            lblSubmit.Text = "Error updating contribution. Please try again later.";
                        }
                    }
                    else if (docBytes != null && !badImg)
                    {
                        if (DBConnection.UpdateContribution(c, title, fileContrib.FileName, filecontenttype, docBytes))
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution updated successfully!";
                        }
                        else
                        {
                            lblSubmit.Text = "Error uploading contribution. Please try again later.";
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewContributions.aspx");
        }
    }
}