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
using static System.Net.Mime.MediaTypeNames;

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

            
            string email = null;
            string password = null;
            string firstName = null;
            string surname = null;
            int phoneNum = 0;
            string streetAddress = null;
            string city = null;
            string message = null;

            //error handling
            if (txtEmail.Value == null)
            {
                lblErrorMessage.Text = "Email error.";
                message = "Email error.";
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                email = txtEmail.Value;
            }

            if (txtPassword.Value == null)
            {
                message = message + "\tPassword error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                password = txtPassword.Value;
            }

            if (txtFirstName.Value == null)
            {
                message = message + "\tName error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                firstName = txtFirstName.Value;
            }

            if (txtSurname.Value == null)
            {
                message = message + "\tSurname error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                surname = txtSurname.Value;
            }

            if (!int.TryParse(txtPhoneNum.Value, out phoneNum))
            {
                message = message + "\tPhone Number error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                phoneNum = Convert.ToInt32(txtPhoneNum.Value);
            }

            if (txtStreetAddress.Value == null)
            {
                message = message + "\tAddress error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                streetAddress = txtStreetAddress.Value;
            }

            if (txtCity.Value == null)
            {
                message = message + "\tCity error.";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }
            else
            {
                city = txtCity.Value;
            }

            // Hash the password
            string salt = hash.GenerateSalt();
            string hashedPassword = hash.HashPasswordSHA256(password, salt);

            if (message == null)
            {
                //try
                //{
                    // Insert the user into the Users table
                    dbHelper.InsertUser(dbHelper.GetLastEnteredUserID()+1, email, hashedPassword, salt);

                    //int userId = dbHelper.GetUserIdByEmail(email);

                    // Insert the farmer into the Farmers table
                    dbHelper.InsertFarmer(dbHelper.GetLastEnteredUserID() + 1, firstName, surname, email, phoneNum, streetAddress, city);

                    // Show completion message
                    lblCompletionMessage.Text = "Farmer added successfully!";
                    lblCompletionMessage.Visible = true;
                    lblErrorMessage.Visible = false;
                //}
                //catch (Exception ex)
                //{
                //    // Show error message
                //    lblErrorMessage.Text = "An error occurred while adding the farmer. Please try again.";
                //    lblErrorMessage.Visible = true;
                //    lblCompletionMessage.Visible = false;
                //}
            }
            else
            {
                message = message + "\tPlease Enter data Correctly";
                lblErrorMessage.Text = message;
                lblErrorMessage.Visible = true;
                lblCompletionMessage.Visible = false;
            }

        }
    }
}
