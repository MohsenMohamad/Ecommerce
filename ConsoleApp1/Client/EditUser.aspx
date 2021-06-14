<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Client.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style20 {
        width: 155px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style5">
    <tr>
        <td class="auto-style20">
            <asp:Label ID="Label3" runat="server" Text="UserName :"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">
            <asp:Label ID="Label4" runat="server" Text="new Password :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="Button3" runat="server" Height="38px" OnClick="Button3_Click" Text="Edit" Width="83px" />
        </td>
    </tr>
</table>
</asp:Content>
