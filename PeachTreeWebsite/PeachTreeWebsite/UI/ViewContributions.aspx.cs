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
				// Populate table with contributions, displaying title, file, image, closure dates, comp name and edit/delete buttons
				DataTable dt = new DataTable();
				dt.Columns.Add("Title");
				dt.Columns.Add("Competition Name");
				dt.Columns.Add("Initial Closure Date");
				dt.Columns.Add("Final Closure Date");
				dt.Columns.Add("File");
				dt.Columns.Add("Image");				
				dt.Columns.Add("Edit");
				dt.Columns.Add("Delete");

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
						dr["File"] = c.DocBytes;
						dr["Image"] = c.ImgBytes;
						dr["Edit"] = "Edit";
						dr["Delete"] = "Delete";
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
			else
			{
				Session.Clear();
				Response.Redirect("~/UI/Default.aspx");
			}
        }
    }
}