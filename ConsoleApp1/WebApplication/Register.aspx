<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Register1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table style="text-align:center; " runat="server" id="Register_table">
             <tr>
             <td>
            <label for="uname"><b>Username</b></label>
             </td>
             <td class="auto-style1">
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username" Width="175px"></asp:TextBox>
             </td>
             <td class="auto-style1">
                     <asp:Label ID="LabelUsername" runat="server" CssClass="red1" Text="what's Your UserName ?"></asp:Label>
             </td>
             </tr>
             <tr>
             <td>
            <label for="psw"><b>Password</b></label>
             </td>
             <td class="auto-style1">
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password" Width="179px"></asp:TextBox>
             </td>
             <td class="auto-style1">
                 <asp:Label ID="LabelPasword" runat="server" CssClass="red1" Text="what's Your Password ?"></asp:Label>
             </td>
             </tr>
             <tr>
             <td>
             </td>
             <td class="auto-style1">
            <asp:Button runat="server" ID="btn_Register" CssClass="lgnbtn" Text="Register" OnClick="btn_Register_Click" />
             </td>
             <td class="auto-style1">
                 &nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style1">
                 </td>
                 <td class="auto-style1">
                     &nbsp;</td>
                 <td class="auto-style1">
                     &nbsp;</td>
             </tr>
         </table>
        </asp:Content>
