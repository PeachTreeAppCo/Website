﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite.UI
{
    public partial class ViewContributions : System.Web.UI.Page
    {
        List<Contribution> contributions = new List<Contribution>();
        List<Competition> competitions = new List<Competition>();
        SiteUser s = new SiteUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
                contributions = DBConnection.getContributionsForUser(s.UserID1);
                competitions = DBConnection.getCompetitons();
                if (!IsPostBack)
                {
                    populateGrid();
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/UI/Default.aspx");
            }
        }

        public void populateGrid()
        {
            contributions = DBConnection.getContributionsForUser(s.UserID1);
            // Populate table with contributions
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Competition Name");
            dt.Columns.Add("Initial Closure Date");
            dt.Columns.Add("Final Closure Date");
            dt.Columns.Add("File");
            dt.Columns.Add("Image");
            dt.Columns.Add("Status");
            dt.Columns.Add("Feedback");

            if (contributions != null)
            {
                foreach (Contribution c in contributions)
                {
                    Competition comp = (from com in competitions
                                        where com.ID1 == c.CompetitionID
                                        select com).First();
                    DataRow dr = dt.NewRow();

                    dr["Title"] = c.Title;
                    dr["Competition Name"] = comp.Name;
                    dr["Initial Closure Date"] = comp.InitialClosure1;
                    dr["Final Closure Date"] = comp.FinalClosure1;
                    dr["File"] = c.DocTitle;
                    dr["Status"] = c.Status;
                    dr["Feedback"] = c.Feedback;
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
                gridviewContrib.DataSource = dt;
                gridviewContrib.DataBind();
            }
            else
            {
                lblError.Text = "No contributions to show! Get writing!";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AddContribution.aspx");
        }

        public void downloadFile(Contribution c)
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
                GridViewRow row = gridviewContrib.Rows[index];
                string title = row.Cells[1].Text;
                Contribution c = (from cont in contributions
                                  where title == cont.Title
                                  select cont).First();
                Competition p = (from comp in competitions
                                 where comp.ID1 == c.CompetitionID
                                 select comp).First();
                downloadFile(c);
            }
            if (e.CommandName == "EditCont")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridviewContrib.Rows[index];
                string title = row.Cells[1].Text;
                Contribution c = (from cont in contributions
                                  where title == cont.Title
                                  select cont).First();
                Competition p = (from comp in competitions
                                 where comp.ID1 == c.CompetitionID
                                 select comp).First();
                if (c.Status != "Published")
                {
                    if (DateTime.Now < p.FinalClosure1)
                    {
                        Session["contSession"] = c;
                        Response.Redirect("~/UI/EditContribution.aspx");
                    }
                    else
                    {
                        lblError.Text = "Competition closed - Cannot edit!";
                    }
                }
                else
                {
                    lblError.Text = "Cannot edit published submissions!";
                }
            }
            if (e.CommandName == "DeleteCont")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridviewContrib.Rows[index];
                string title = row.Cells[1].Text;
                Contribution c = (from cont in contributions
                                  where title == cont.Title
                                  select cont).First();
                Competition p = (from comp in competitions
                                 where comp.ID1 == c.CompetitionID
                                 select comp).First();
                if (c.Status != "Published")
                {
                    if (DateTime.Now < p.FinalClosure1)
                    {
                        DBConnection.deleteContribution(c);
                        populateGrid();
                    }
                    else
                    {
                        lblError.Text = "Competition closed - Cannot delete!";
                    }
                }
                else
                {
                    lblError.Text = "Cannot delete published submissions!";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/TermsAndConditions.aspx");
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewContrib.PageIndex = e.NewPageIndex;
            populateGrid();
        }
    }
}