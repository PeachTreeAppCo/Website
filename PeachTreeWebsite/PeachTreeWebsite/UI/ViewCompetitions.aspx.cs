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
            dt.Columns.Add("Competition Year");
            dt.Columns.Add("Initial Closure Date");
            dt.Columns.Add("Final Closure Date");

            if (competitions != null)
            {
                foreach (Competition c in competitions)
                {
                    DataRow dr = dt.NewRow();
                    
                    dr["Competition Year"] = c.Name;
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
            if (e.CommandName == "EditComp")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string name = row.Cells[1].Text;
                Competition c = (from comp in competitions
                                 where comp.Name == name
                                 select comp).First();
                if (c.FinalClosure1 > DateTime.Now)
                {
                    Session["compSession"] = c;
                    Response.Redirect("~/UI/EditCompetition.aspx");
                }
                else
                {
                    lblError.Text = "Cannot edit a competition that has already closed!";
                }
            }
        }

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AddCompetition.aspx");
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populateGrid();
        }
    }
}