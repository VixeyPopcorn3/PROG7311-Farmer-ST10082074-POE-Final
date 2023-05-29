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
    public partial class Products : System.Web.UI.Page
    {
        private DatabaseHelper dbHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbHelper = new DatabaseHelper();
            if (!IsPostBack)
            {
                if (Request.QueryString["LoginID"] != null)
                {
                    if (int.TryParse(Request.QueryString["LoginID"], out int loginID))
                    {
                        BindProductData(loginID);
                        BindProductTypes(loginID);
                    }
                }
            }
        }

        private void BindProductData(int loginID)
        {
            DataTable dt = dbHelper.GetProductsByFarmerID(loginID);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void BindProductTypes(int loginID)
        {
            DataTable dt = dbHelper.GetDistinctProductTypes(loginID);
            ddlProductType.DataSource = dt;
            ddlProductType.DataTextField = "Name";
            ddlProductType.DataValueField = "Name";
            ddlProductType.DataBind();

            ddlProductType.Items.Insert(0, new ListItem("All", ""));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllFarmers.aspx");
        }

        protected void btnFilterDate_Click(object sender, EventArgs e)
        {
            DateTime startDate, endDate;
            if (DateTime.TryParse(txtStartDate.Text, out startDate) && DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                int loginID;
                if (int.TryParse(Request.QueryString["loginID"], out loginID))
                {
                    FilterProductsByDate(loginID, startDate, endDate);
                }
            }
        }

        private void FilterProductsByDate(int loginID, DateTime startDate, DateTime endDate)
        {
            DataTable dt = dbHelper.GetProductsByDateRange(loginID, startDate, endDate);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int loginID;
            if (int.TryParse(Request.QueryString["loginID"], out loginID))
            {
                string selectedProductType = ddlProductType.SelectedValue;
                if (string.IsNullOrEmpty(selectedProductType))
                {
                    BindProductData(loginID);
                }
                else
                {
                    FilterProductsByType(loginID, selectedProductType);
                }
            }
        }

        private void FilterProductsByType(int loginID, string productType)
        {
            DataTable dt = dbHelper.GetProductsByType(loginID, productType);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}