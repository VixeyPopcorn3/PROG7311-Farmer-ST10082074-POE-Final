<%@ Page Title="Add Farmer" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Employee/Employee.master" CodeBehind="AddFarmer.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.AddFarmer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmployeeContent" runat="server">
<style>
    body {
        background-color: purple;
        color: white;
        font-family: Arial, sans-serif;
    }

    .container {
        max-width: 600px;
        margin: 50px auto;
        padding: 20px;
        background-color: #fff;
        border: 1px solid #ddd;
    }

    .container h1 {
        text-align: center;
        color: black;
    }

    .form-group {
        margin-bottom: 15px;
    }

    .form-group label {
        display: block;
        font-weight: bold;
        color: black;
    }

    .form-group input[type="text"],
    .form-group input[type="password"],
    .form-group input[type="number"] {
        width: 100%;
        padding: 10px;
        font-size: 16px;
    }

    .form-group input[type="submit"] {
        background-color: white;
        color: purple;
        font-size: 16px;
        padding: 10px 20px;
        border: none;
        cursor: pointer;
    }

    .completion-message {
        color: green;
        font-weight: bold;
        margin-top: 10px;
    }

    .error-message {
        color: red;
        font-weight: bold;
        margin-top: 10px;
    }
</style>

    <div class="container">
        <h1>Add Farmer</h1>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <input type="text" id="txtEmail" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtPassword">Password:</label>
            <input type="password" id="txtPassword" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtFirstName">First Name:</label>
            <input type="text" id="txtFirstName" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtSurname">Surname:</label>
            <input type="text" id="txtSurname" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtPhoneNum">Phone Number:</label>
            <input type="number" id="txtPhoneNum" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtStreetAddress">Street Address:</label>
            <input type="text" id="txtStreetAddress" runat="server" />
        </div>
        <div class="form-group">
            <label for="txtCity">City:</label>
            <input type="text" id="txtCity" runat="server" />
        </div>
        <div class="form-group">
            <input type="submit" id="btnAddFarmer" runat="server" value="Add Farmer" OnClick="btnAddFarmer_Click" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblCompletionMessage" runat="server" CssClass="completion-message" Visible="false"></asp:Label>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
