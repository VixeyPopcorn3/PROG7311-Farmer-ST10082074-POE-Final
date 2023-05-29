using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PROG7311_Farmer_ST10082074.Classes;

namespace PROG7311_Farmer_ST10082074
{
    public partial class AllFarmers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFarmersData();
            }
        }
        private void BindFarmersData()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            DataTable dt = dbHelper.GetAllFarmers();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GridViewRow selectedRow = GridView1.SelectedRow;

            string loginID = selectedRow.Cells[6].Text; 

            Response.Redirect("Products.aspx?LoginID=" + loginID);
        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFarmer.aspx");
        }
    }
}