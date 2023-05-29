<%@ Page Title="Farmer Products" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Farmer/Farmer.master" CodeBehind="FarmerProd.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.FarmerProd" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="FarmerContent" runat="server">

        <div>
            <h1>Farmer's Products</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Desc" HeaderText="Description" />
                    <asp:BoundField DataField="DateAdded" HeaderText="Date Added" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
