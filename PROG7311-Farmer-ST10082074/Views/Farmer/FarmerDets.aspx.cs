using PROG7311_Farmer_ST10082074.Classes;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace PROG7311_Farmer_ST10082074
{
    public partial class FarmerDets : System.Web.UI.Page
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
                    LoadFarmerDetails();
                }
            }
        }

        // Load farmer details from the database and display them
        private void LoadFarmerDetails()
        {
            int loginId = Convert.ToInt32(Session["UserId"]);
            DataTable farmerDetails = DatabaseHelper.GetFarmerDetails(loginId);

            if (farmerDetails.Rows.Count > 0)
            {
                DataRow row = farmerDetails.Rows[0];
                firstName.InnerText = row["FName"].ToString();
                surname.InnerText = row["SName"].ToString();
                email.InnerText = row["Email"].ToString();
                phone.InnerText = row["PhoneNum"].ToString();
                address.InnerText = row["StreatAddress"].ToString();
                city.InnerText = row["City"].ToString();
                loginID.InnerText = row["LoginID"].ToString();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Set the edit fields' values to the current displayed values
            txtFirstName.Value = firstName.InnerText;
            txtSurname.Value = surname.InnerText;
            txtPhone.Value = phone.InnerText;
            txtAddress.Value = address.InnerText;
            txtCity.Value = city.InnerText;

            // Show edit fields and hide labels
            firstName.Visible = false;
            surname.Visible = false;
            phone.Visible = false;
            address.Visible = false;
            city.Visible = false;

            txtFirstName.Style["display"] = "inline-block";
            txtSurname.Style["display"] = "inline-block";
            txtPhone.Style["display"] = "inline-block";
            txtAddress.Style["display"] = "inline-block";
            txtCity.Style["display"] = "inline-block";

            btnEdit.Visible = false;
            btnSave.Style["display"] = "block";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Get the updated values from the edit fields
            string updatedFirstName = txtFirstName.Value;
            string updatedSurname = txtSurname.Value;
            string updatedPhone = txtPhone.Value;
            string updatedAddress = txtAddress.Value;
            string updatedCity = txtCity.Value;

            int loginId = Convert.ToInt32(Session["UserId"]);
            DatabaseHelper.UpdateFarmerDetails(loginId, updatedFirstName, updatedSurname, updatedPhone, updatedAddress, updatedCity);

            // Update the displayed values
            firstName.InnerText = updatedFirstName;
            surname.InnerText = updatedSurname;
            phone.InnerText = updatedPhone;
            address.InnerText = updatedAddress;
            city.InnerText = updatedCity;

            // Show labels and hide edit fields
            firstName.Visible = true;
            surname.Visible = true;
            phone.Visible = true;
            address.Visible = true;
            city.Visible = true;

            txtFirstName.Style["display"] = "none";
            txtSurname.Style["display"] = "none";
            txtPhone.Style["display"] = "none";
            txtAddress.Style["display"] = "none";
            txtCity.Style["display"] = "none";

            btnEdit.Visible = true;
            btnSave.Style["display"] = "none";
        }
    }
}
