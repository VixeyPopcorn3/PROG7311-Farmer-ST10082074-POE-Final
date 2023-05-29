<%@ Page Title="About" Language="C#" MasterPageFile="~/Views/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="EmpAbout.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmployeeContent" runat="server">
        <style>
        .about-section h2,
        .feature-section h3,
        .motivation-section h3 {
            font-family: 'Pacifico', cursive;
            color: #ff9800;
            margin-bottom: 15px;
        }

        .about-section p,
        .feature-section ul,
        .motivation-section p {
            font-family: 'Arial', sans-serif;
            font-size: 16px;
            color: #555;
            margin-bottom: 15px;
        }
    </style>
    <div class="about-section">
        <h2>About</h2>
        <p>Welcome to our employee portal, where you have access to manage and interact with the farmer database. This platform empowers you to view, add, and update farmers' information, as well as explore the products they offer.</p>
    </div>

    <div class="feature-section">
        <h3>Features:</h3>
        <ul>
            <li>View All Farmers: Access the database to see a comprehensive list of all registered farmers.</li>
            <li>Add Farmers: Easily add new farmers to the database with their details.</li>
            <li>View Products: Select a farmer from the list to view their available products.</li>
            <li>View Your Details: Check your own employee details.</li>
        </ul>
    </div>

    <div class="motivation-section">
        <h3>Empowering You as an Employee</h3>
        <p>At our company, we believe that every employee has the power to make a difference. By managing and nurturing the farmer database, you play a crucial role in connecting farmers with customers and promoting sustainable agriculture. Your dedication and contributions help to strengthen local communities and support the growth of the agricultural industry.</p>
        <p>Remember, your efforts matter, and the work you do here makes a positive impact. We encourage you to continue exploring new opportunities, fostering meaningful connections, and striving for excellence. Together, we can build a brighter future for farmers and consumers alike.</p>
    </div>

</asp:Content>

