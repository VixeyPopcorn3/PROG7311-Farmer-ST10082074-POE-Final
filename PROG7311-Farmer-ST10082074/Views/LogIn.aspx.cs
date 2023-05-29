using PROG7311_Farmer_ST10082074.Classes;
using System;

namespace PROG7311_Farmer_ST10082074
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Create instances of helper classes
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Get email and password from the input fields
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // Validate user credentials
            if (dbHelper.ValidateUser(email, password))
            {
                bool userType = dbHelper.GetUserType(email);

                // Authentication successful, redirect to another page based on user type
                if (userType) // User is an farmer
                {
                    Session["UserId"] = dbHelper.GetUserIdByEmail(email);
                    Response.Redirect("Farmer/FarmAbout.aspx");
                }
                else // User is a employee
                {
                    Session["UserId"] = dbHelper.GetUserIdByEmail(email);
                    Response.Redirect("Employee/EmpAbout.aspx");
                    
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid email or password.";
            }
        }

    }
}
