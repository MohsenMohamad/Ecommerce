<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Open_shop.aspx.cs" Inherits="Client.Open_shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 151px;
        }
        .style_send {
             background-color: forestgreen;
             color: white;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style5">
        <tr>
            <td class="auto-style10">
                <asp:Label ID="shopNameLabel" runat="server" Text="shopName :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxShopname" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="policyLabel" runat="server" Text="policy :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxpolicy" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="Labelerror" runat="server" Text="error"></asp:Label>
            </td>
            <td>
                <asp:Button ID="ButtonSend" class ="style_send"   runat="server" Text="Send" Height="33px" OnClick="ButtonSend_Click" Width="84px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
