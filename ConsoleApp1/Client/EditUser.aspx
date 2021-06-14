<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Client.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style20 {
        width: 155px;
    }
    .auto-style22 {
        width: 188px;
    }
    .auto-style23 {
        width: 348px;
    }
    .auto-style24 {
        width: 188px;
        height: 54px;
    }
    .auto-style25 {
        width: 348px;
        height: 54px;
    }
    .auto-style26 {
        height: 54px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style5">
    <tr>
        <td class="auto-style24">
            <asp:Label ID="Label3" runat="server" Text="UserName :"></asp:Label>
        </td>
        <td class="auto-style25">
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="auto-style26"></td>
    </tr>
    <tr>
        <td class="auto-style22">
            <asp:Label ID="Label4" runat="server" Text="new Password :"></asp:Label>
        </td>
        <td class="auto-style23">
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style22">&nbsp;</td>
        <td class="auto-style23">&nbsp;</td>
        <td>
            <asp:Button ID="Button3" runat="server" Height="38px" OnClick="Button3_Click" Text="Edit" Width="83px" />
        </td>
    </tr>
</table>
</asp:Content>
