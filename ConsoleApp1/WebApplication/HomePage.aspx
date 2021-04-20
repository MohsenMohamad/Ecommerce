<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 39px;
        }
        .auto-style1 {
            height: 26px;
        }
        #LoginTable {
            height: 136px;
            width: 318px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        Welcome to Market<p>
        <asp:Button ID="Button1" runat="server" Height="54px" OnClick="Button1_Click" Text="Register" Width="142px" />
            <asp:Label ID="welcome" runat="server"></asp:Label>
        </p>
        <div>
         <table style="width: 400px;" runat="server" id="Login_table">
             <tr>
             <td>
                 <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
             </td>
             </tr>
             <tr>
             <td>
                 <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
             </td>
             </tr>
             <tr>
             <td>
             </td>
             <td>
                 <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
             </td>
             </tr>
             <tr>
                 <td class="auto-style1">
                 </td>
                 <td class="auto-style1">
                     <asp:Label ID="Label3" runat="server" Text="Error"></asp:Label>
                 </td>
             </tr>
         </table>
        </div>
    </form>
</body>
</html>
