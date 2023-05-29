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
using System.Net;
using System.Security.Policy;

namespace PROG7311_Farmer_ST10082074
{
    public partial class EmployeeDets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect to login page if not logged in
                }
                else
                {
                    LoadEmployeeDetails();
                }
            }
        }

        protected void LoadEmployeeDetails()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            DataTable empDetails = DatabaseHelper.GetEmployeeDetails(userId);

            if (empDetails.Rows.Count > 0)
            {
                DataRow row = empDetails.Rows[0];
                firstName.InnerText = row["FName"].ToString();
                surname.InnerText = row["SName"].ToString();
                email.InnerText = row["Email"].ToString();
                phone.InnerText = row["PhoneNum"].ToString();
                loginID.InnerText = row["LoginID"].ToString();
            }
        }
    }
}