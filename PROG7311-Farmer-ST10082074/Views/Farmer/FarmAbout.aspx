<%@ Page Title="About" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Farmer/Farmer.master" CodeBehind="FarmAbout.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.FarmAbout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FarmerContent" runat="server">
    <style>
        .section-heading {
            font-family: 'Pacifico', cursive;
            color: #ff9800;
            margin-bottom: 15px;
        }

        .section-content {
            font-family: 'Arial', sans-serif;
            font-size: 16px;
            color: #555;
            margin-bottom: 15px;
        }
    </style>
    <div class="section">
        <h2 class="section-heading">Welcome to Our Farmer's Website!</h2>
        <p class="section-content">
            We are dedicated to supporting and empowering farmers like you. Our website provides a platform for you
            to showcase your products and manage your farm inventory efficiently. With easy access to your product
            database, you can stay organized and keep track of your offerings in one convenient place.
        </p>
    </div>

    <div class="section">
        <h3 class="section-heading">Manage Your Product Database</h3>
        <p class="section-content">
            Our user-friendly interface allows you to view and manage your own products with ease. Now that you are logged in to
            your farmer account, you'll have complete control over your inventory. Being able to add new products. Stay up to date and ensure accurate information for your
            customers.
        </p>
    </div>

    <div class="section">
        <h3 class="section-heading">Our Shared Vision</h3>
        <p class="section-content">
            We believe in fostering a strong and sustainable farming community. By providing you with the tools to
            manage your products effectively, we aim to empower you in your farming journey. Together, we can create
            a thriving marketplace that connects farmers with consumers, promoting transparency and
            supporting local agriculture.
        </p>
    </div>

    <div class="section">
        <h3 class="section-heading">View Your Farm Profile</h3>
        <p class="section-content">
            Along with managing your products, you can also view and update your details.
        </p>
    </div>
</asp:Content>
