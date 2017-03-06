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
    public partial class ViewCompetitions : System.Web.UI.Page
    {
        SiteUser s = new SiteUser();
        List<Competition> competitions = new List<Competition>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ContSession"] = null;
            if (Session["UserSession"] != null)
            {
                s = (SiteUser)Session["UserSession"];
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
            competitions = DBConnection.getCompetitons();
            // Populate table with contributions
            DataTable dt = new DataTable();
            dt.Columns.Add("Competition ID");
            dt.Columns.Add("Competition Name");
            dt.Columns.Add("Initial Closure Date");
            dt.Columns.Add("Final Closure Date");

            if (competitions != null)
            {
                foreach (Competition c in competitions)
                {
                    DataRow dr = dt.NewRow();

                    dr["Competition ID"] = c.ID1;
                    dr["Competition Name"] = c.Name;
                    dr["Initial Closure Date"] = c.InitialClosure1;
                    dr["Final Closure Date"] = c.FinalClosure1;
                    dt.Rows.Add(dr);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            int id = int.Parse(row.Cells[1].Text);
            Competition c = (from comp in competitions
                             where comp.ID1 == id
                             select comp).First();

            if (e.CommandName == "EditComp")
            {
                Session["compSession"] = c;
                Response.Redirect("~/UI/EditCompetition.aspx");
            }
            if (e.CommandName == "DeleteComp")
            {
                DBConnection.deleteCompetition(c);
                populateGrid();
            }
        }

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AddCompetition.aspx");
        }
    }
}