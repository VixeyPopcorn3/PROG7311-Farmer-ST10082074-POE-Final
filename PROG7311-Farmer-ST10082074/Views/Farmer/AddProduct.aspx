<%@ Page Title="Add Product" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Farmer/Farmer.master" CodeBehind="AddProduct.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.AddProduct" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="FarmerContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            font-size: 24px;
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 10px;
            font-weight: bold;
        }

        .input-container {
            margin-bottom: 20px;
        }

        .input-container input[type="text"],
        .input-container input[type="date"],
        .input-container input[type="number"] {
            width: 300px;
            padding: 5px;
            font-size: 14px;
        }

        .submit-container {
            margin-top: 20px;
        }

        .message {
            margin-top: 10px;
            color: green;
            font-weight: bold;
        }

        .error-message {
            margin-top: 10px;
            color: red;
            font-weight: bold;
        }
    </style>
        <h1>Add Product</h1>
        <div class="input-container">
            <label for="txtName">Name:</label>
            <input id="txtName" type="text" runat="server" />
        </div>
        <div class="input-container">
            <label for="txtDesc">Description:</label>
            <input id="txtDesc" type="text" runat="server" />
        </div>
        <div class="input-container">
            <label for="txtDateAdded">Date Added:</label>
            <input id="txtDateAdded" type="date" runat="server" />
        </div>
        <div class="input-container">
            <label for="txtQuantity">Quantity:</label>
            <input id="txtQuantity" type="number" runat="server" />
        </div>
        <div class="submit-container">
            <input id="btnAddProduct" type="submit" runat="server" value="Add Product" OnClick="btnAddProduct_Click" />
        </div>
        <div class="message" runat="server" visible="false">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
</asp:Content>
