<%@ Page Title="Farmer Details" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Farmer/Farmer.master" CodeBehind="FarmerDets.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.FarmerDets" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="FarmerContent" runat="server">
    <style>
        body {
            background-color: #E6E6FA; /* Soft purple */
        }
        
        .container {
            max-width: 500px;
            margin: 50px auto;
            background-color: #FFFFFF; /* White */
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.3);
        }
        
        .field-label {
            font-weight: bold;
        }
        
        .field-value {
            margin-bottom: 10px;
        }
        
        .edit-link {
            display: block;
            color: blue;
            margin-top: 10px;
            text-decoration: underline;
            cursor: pointer;
        }
        
        .edit-field {
            width: 250px;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        
        .save-button {
            margin-top: 10px;
        }
    </style>

    <div class="container">
        <h2>Farmer Details</h2>
        <hr />
        <div class="field-value">
            <span class="field-label">First Name:</span>
            <span id="firstName" runat="server"></span>
            <input type="text" id="txtFirstName" class="edit-field" runat="server" style="display:none" />
        </div>
        <div class="field-value">
            <span class="field-label">Surname:</span>
            <span id="surname" runat="server"></span>
            <input type="text" id="txtSurname" class="edit-field" runat="server" style="display:none" />
        </div>
        <div class="field-value">
            <span class="field-label">Email:</span>
            <span id="email" runat="server"></span>
        </div>
        <div class="field-value">
            <span class="field-label">Phone Number:</span>
            <span id="phone" runat="server"></span>
            <input type="text" id="txtPhone" class="edit-field" runat="server" style="display:none" />
        </div>
        <div class="field-value">
            <span class="field-label">Street Address:</span>
            <span id="address" runat="server"></span>
            <input type="text" id="txtAddress" class="edit-field" runat="server" style="display:none" />
        </div>
        <div class="field-value">
            <span class="field-label">City:</span>
            <span id="city" runat="server"></span>
            <input type="text" id="txtCity" class="edit-field" runat="server" style="display:none" />
        </div>
        <div class="field-value">
            <span class="field-label">Login ID:</span>
            <span id="loginID" runat="server"></span>
        </div>
        <div>
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="edit-link" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="edit-link save-button" Style="display:none" />
        </div>
    </div>
</asp:Content>
