<%@ Page Title="Selected Farmers Products" Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.Products" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selected Farmers - List of Products</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: lavender;
            color: #333;
        }

        .container {
            margin-top: 20px;
            background-color: lavenderblush;
            padding: 20px;
            border: 1px solid lavender;
        }

        h2 {
            color: purple;
            margin-bottom: 20px;
        }

        .gridview {
            border-collapse: collapse;
            width: 100%;
        }

        .gridview th,
        .gridview td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .back-button {
            margin-bottom: 10px;
            background-color: purple;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
        }

        .back-button:hover {
            background-color: darkpurple;
        }

        .filter-section {
            margin-bottom: 20px;
        }

        .filter-label {
            font-weight: bold;
            color: purple;
        }

        .date-input {
            padding: 4px;
            border: 1px solid #ccc;
        }

        .apply-button {
            background-color: purple;
            color: white;
            padding: 4px 8px;
            border: none;
            cursor: pointer;
        }

        .apply-button:hover {
            background-color: darkpurple;
        }

        .dropdownlist {
            padding: 4px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Selected Farmers - List of Products</h2>
            <div class="filter-section">
                <span class="filter-label">Filter by Date Range:</span>
                <asp:TextBox ID="txtStartDate" runat="server" placeholder="Start Date" CssClass="date-input"></asp:TextBox>
                <asp:TextBox ID="txtEndDate" runat="server" placeholder="End Date" CssClass="date-input"></asp:TextBox>
                <asp:Button ID="btnFilterDate" runat="server" Text="Apply" CssClass="apply-button" OnClick="btnFilterDate_Click" />
            </div>
            <div class="filter-section">
                <span class="filter-label">Filter by Product Type:</span>
                <asp:DropDownList ID="ddlProductType" runat="server" CssClass="dropdownlist" AutoPostBack="true" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged">
                    <asp:ListItem Text="All" Value=""></asp:ListItem>
                    <asp:ListItem Text="Type 1" Value="Type 1"></asp:ListItem>
                    <asp:ListItem Text="Type 2" Value="Type 2"></asp:ListItem>
                    <asp:ListItem Text="Type 3" Value="Type 3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button" OnClick="btnBack_Click" />
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Product ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Desc" HeaderText="Description" />
                    <asp:BoundField DataField="DateAdded" HeaderText="Date Added" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

