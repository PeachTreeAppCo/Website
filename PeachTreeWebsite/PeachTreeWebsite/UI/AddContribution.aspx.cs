﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
        int uploadedContID;

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
            competitions = DBConnection.getCompetitons();
            if (!IsPostBack)
            {
                ddlComps.Items.Clear();
                foreach (Competition c in competitions)
                {
                    if (DateTime.Now < c.InitialClosure1)
                    {
                        ddlComps.Items.Add(c.Name);
                    }
                }
                ddlComps.SelectedIndex = 0;
            }
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
                        uploadedContID = DBConnection.UploadFileWithImg(title, fileContrib.FileName, filecontenttype, docBytes, fileImage.FileName, imgBytes, s.UserID1, compID);
                        if (uploadedContID != -1)
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution and image uploaded successfully!";
                            emailMarketingCoordinator(uploadedContID, title);
                        }
                        else
                        {
                            lblSubmit.Text = "Error uploading files. Please try again later.";
                        }
                    }
                    else if (docBytes != null && !badImg)
                    {
                        uploadedContID = DBConnection.UploadFile(title, fileContrib.FileName, filecontenttype, docBytes, s.UserID1, compID);
                        if (uploadedContID != -1)
                        {
                            cbTerms.Checked = false;
                            txtTitle.Text = "";
                            lblSubmit.Text = "Contribution uploaded successfully!";
                            emailMarketingCoordinator(uploadedContID, title);
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

        public void emailMarketingCoordinator(int uploadedContID, string title)
        {
            string mcEmail = DBConnection.getMarketingCoordinatorEmail(uploadedContID);
            if (mcEmail != "")
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(mcEmail);
                mail.From = new MailAddress("peachtree.greenwich@gmail.com", "PeachTree Submissions", System.Text.Encoding.UTF8);
                mail.Subject = "[PeachTree] You have a new magazine contribution for your faculty!";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "<div class='jumbotron'><h1>You have a new magazine contribution for your faculty!</h1></div>"
                    + "<br/>Please log into the system to give feedback within <strong>14 days</strong>."
                    + "<br/><br/>Title: <strong>" + title + "</strong>"
                    + "<br/>Author: <strong>" + s.GivenName1 + " " + s.Surname1 + "</strong>"
                    + "<br/>Email address: <strong>" + s.Email1 + "</strong>"
                    + "<br/><br/>Kind regards,"
                    + "<br/>PeachTree";
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("peachtree.greenwich@gmail.com", "PeachTree123");
                client.Port = 587;
                client.Timeout = 10000;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
            }
        }
    }
}