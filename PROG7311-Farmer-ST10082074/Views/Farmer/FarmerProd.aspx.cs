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
    public partial class FarmerProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }
        // Bind the farmer's products to the GridView
        private void BindProducts()
        {
            int farmerId = Convert.ToInt32(Session["UserId"]);
            DataTable dataTable = DatabaseHelper.GetProducts(farmerId);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}
