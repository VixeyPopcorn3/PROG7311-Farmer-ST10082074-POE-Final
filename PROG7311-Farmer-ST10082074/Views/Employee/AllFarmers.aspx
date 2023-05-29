<%@ Page Title="All Farmers" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Employee/Employee.master" CodeBehind="AllFarmers.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.AllFarmers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmployeeContent" runat="server">
    <style>
        .container {
            margin-top: 20px;
        }
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }
        .gridview th, .gridview td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        .header-section {
            margin-bottom: 20px;
            background-color: purple;
            color: white;
            padding: 10px;
        }
        .add-button {
            background-color: purple;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
        }
        .add-button:hover {
            background-color: darkpurple;
        }
        .gridview-row:hover {
            background-color: lightgray;
            cursor: pointer;
        }
    </style>

    <div class="container">
        <div class="header-section">
            <h2>Farmers - List</h2>
        </div>
        <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" CssClass="add-button" OnClick="btnAddFarmer_Click" />    
        <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Select" ShowSelectButton="true" />
            <asp:BoundField DataField="FName" HeaderText="First Name" />
            <asp:BoundField DataField="SName" HeaderText="Surname" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNum" HeaderText="Phone Number" />
            <asp:BoundField DataField="StreatAddress" HeaderText="Street Address" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="LoginID" HeaderText="Login ID" />
        </Columns>
        <RowStyle CssClass="gridview-row" />
       </asp:GridView>
    </div>
</asp:Content>

