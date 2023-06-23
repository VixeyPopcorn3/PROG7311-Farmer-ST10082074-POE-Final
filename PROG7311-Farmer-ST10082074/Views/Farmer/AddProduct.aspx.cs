using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PROG7311_Farmer_ST10082074.Classes;

namespace PROG7311_Farmer_ST10082074
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddProduct_Click(object sender, EventArgs e) 
        {
            lblMessage.Text = "Hello";

            //lblMessage.Text = "";
            //lblMessage.Visible = false;

            string message = null;
            // Get the product details from the input fields
            string name = "";
            string description = "";
            DateTime dateAdded;
            int quantity;

            if (txtName.Value == null)
            {
                lblMessage.Text = "Invalid Name.";
                message = "Invalid Name.";
                //lblMessage.Visible = true;
            }
            else
            {
                name = txtName.Value;
            }

            if (txtDesc.Value == null)
            {
                message = message + "\nInvalid Description.";
                lblMessage.Text = message;
                //lblMessage.Visible = true;
            }
            else
            {
                description = txtDesc.Value;
            }

            // Validate and parse the date added
            if (!DateTime.TryParse(txtDateAdded.Value, out dateAdded))
            {
                message = message + "\nInvalid Date Added format.";
                lblMessage.Text = message;
                //lblMessage.Visible = true;
            }
            else
            {
                dateAdded = DateTime.Parse(txtDateAdded.Value);
            }

            // Validate and parse the quantity
            if (!int.TryParse(txtQuantity.Value, out quantity) || txtQuantity == null)
            {
                message = message + "\nInvalid Quantity format.";
                lblMessage.Text = message;
                //lblMessage.Visible = true;
            }
            else
            {
                quantity = int.Parse(txtQuantity.Value);
            }

            if(message == null)// || lblMessage.Visible = false;
            {
                // Get the farmer ID from the session
                int farmerId = Convert.ToInt32(Session["UserId"]);

                // Create an instance of the DatabaseHelper class
                DatabaseHelper dbHelper = new DatabaseHelper();

                // Add the product to the database
                bool success = dbHelper.AddProduct(name, description, dateAdded, quantity, farmerId);

                // Display appropriate message based on the success status
                if (success)
                {
                    lblMessage.Text = "Product added successfully.";
                    //lblMessage.Visible = true;
                    ClearFields();
                }
                else
                {
                    lblMessage.Text = "Failed to add product.";
                    //lblMessage.Visible = true;
                }
            }
            else
            {
                message = message + "\nPlease Correct these Errors";
                lblMessage.Text = message;
                //lblMessage.Visible = true;
            }
        }

        private void ClearFields()
        {
            // Clear the input fields
            txtName.Value = string.Empty;
            txtDesc.Value = string.Empty;
            txtDateAdded.Value = string.Empty;
            txtQuantity.Value = string.Empty;
        }
    }
}
