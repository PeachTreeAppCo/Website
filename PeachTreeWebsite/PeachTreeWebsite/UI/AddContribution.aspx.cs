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
            Session["ContSession"] = null;
            ddlComps.Items.Clear();
            competitions = DBConnection.getCompetitons();
            foreach (Competition c in competitions)
            {
                if (DateTime.Now < c.InitialClosure1)
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
                        if(DBConnection.UploadFileWithImg(title, fileContrib.FileName, filecontenttype, docBytes, fileImage.FileName, imgBytes, s.UserID1, compID))
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
                        if(DBConnection.UploadFile(title, fileContrib.FileName, filecontenttype, docBytes, s.UserID1, compID))
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
            Response.Redirect("~/UI/TermsAndConditions.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ViewContributions.aspx");
        }
    }
}