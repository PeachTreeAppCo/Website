using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ViewPublications : System.Web.UI.Page
    {
        List<PublishedContribution> contributions = new List<PublishedContribution>();
        List<Competition> competitions = new List<Competition>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null || Session["FacultySession"] != null || Session["GuestSession"] != null)
            {
                competitions = DBConnection.getCompetitons();
                
                if (!IsPostBack)
                {
                    contributions = DBConnection.getPublishedContributions();
                    ddlComps.Items.Clear();
                    foreach (Competition c in competitions)
                    {
                        ddlComps.Items.Add(c.Name);
                    }
                    ddlComps.SelectedIndex = 0;
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
        }

        public void populateGrid(List<PublishedContribution> contributions)
        {
            // Populate table with contributions
            DataTable dt = new DataTable();
            dt.Columns.Add("Author");
            dt.Columns.Add("Faculty");
            dt.Columns.Add("Title");
            dt.Columns.Add("Competition Name");
            dt.Columns.Add("File");
            dt.Columns.Add("Image");

            if (contributions != null)
            {
                foreach (PublishedContribution c in contributions)
                {
                    DataRow dr = dt.NewRow();

                    dr["Author"] = c.FName + " " + c.SName;
                    dr["Faculty"] = c.FacultyName;
                    dr["Title"] = c.Title;
                    dr["Competition Name"] = c.CompetitionName;
                    dr["File"] = c.DocTitle;

                    if (c.ImgTitle != null)
                    {
                        dr["Image"] = c.ImgTitle;
                    }
                    else
                    {
                        dr["Image"] = "No image";
                    }
                    dt.Rows.Add(dr);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public void downloadFile(PublishedContribution c)
        {
            Response.AddHeader("Content-type", c.DocContentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + c.DocTitle);
            Response.BinaryWrite(c.DocBytes);
            Response.Flush();
            Response.End();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string title = row.Cells[3].Text;
                PublishedContribution c = (from cont in contributions
                                           where title == cont.Title
                                           select cont).First();
                downloadFile(c);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlComps.SelectedItem != null)
            {
                contributions = DBConnection.getPublishedContributionsForComp(ddlComps.SelectedItem.ToString());
                populateGrid(contributions);
            }
            else
            {
                lblErr.Text = "Select a year";
            }
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            contributions = DBConnection.getPublishedContributionsForComp(ddlComps.SelectedItem.ToString());
            populateGrid(contributions);
        }
    }
}