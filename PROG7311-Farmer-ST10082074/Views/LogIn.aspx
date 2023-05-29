<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PROG7311_Farmer_ST10082074.LogIn" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <style>
        body {
            background-color: #e6e6ff;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-form {
            background-color: #f5f5ff;
            padding: 20px;
            border-radius: 8px;
            text-align: center;
        }

        .form-control {
            width: 250px;
            height: 30px;
            margin: 10px;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn-primary {
            background-color: #9370db;
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 4px;
            cursor: pointer;
        }

        .error-message {
            color: red;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-form">
            <h2 style="color: #9370db;">Login</h2>
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
            <br />
            <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
            <br />
            <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
