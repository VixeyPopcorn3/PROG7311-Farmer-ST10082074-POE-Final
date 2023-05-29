using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PROG7311_Farmer_ST10082074.Classes;

namespace PROG7311_Farmer_ST10082074
{
    public partial class AddFarmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            Hashing hash = new Hashing();

            string email = txtEmail.Value.Trim();
            string password = txtPassword.Value.Trim();
            string firstName = txtFirstName.Value.Trim();
            string surname = txtSurname.Value.Trim();
            int phoneNum = Convert.ToInt32(txtPhoneNum.Value.Trim());
            string streetAddress = txtStreetAddress.Value.Trim();
            string city = txtCity.Value.Trim();

            // Hash the password
            string salt = hash.GenerateSalt();
            string hashedPassword = hash.HashPasswordSHA256(password, salt);

            try
            {
                // Insert the user into the Users table
                dbHelper.InsertUser(email, hashedPassword, salt);

                int userId = dbHelper.GetUserIdByEmail(email);

                // Insert the farmer into the Farmers table
                dbHelper.InsertFarmer(userId, firstName, surname, email, phoneNum, streetAddress, city);

                // Show completion message
                lblCompletionMessage.Text = "Farmer added successfully!";
                lblCompletionMessage.Visible = true;
                lblErrorMessage.Visible = false;
            }
            catch (Exception ex)
            {
                // Show error message
                lblErrorMessage.Text = "An error occurred while adding the farmer. Please try again.";
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
        }
    }
}
