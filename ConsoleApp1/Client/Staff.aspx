<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Client.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="Data_cart" runat="server" Width="100%" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged">
        <ItemTemplate>
            <table align="center" style="width: 100%; border-bottom: 1px solid #CCC; ">
                <tr>
                    <td style="text-align: center; width: 60px;">
                        <td style="width: 10px;"></td>
                        <td style="width: 302px">
                            <table align="left" >
                                <tr>
                                    <td style="text-align: left;">
                                        <br />
                                        <span style="font-size: 14px; font-weight: 700; text-shadow:1px 1px red">--</span><span><%#Eval("id")%></span></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;"><span style="font-size: 14px; font-weight: 700; text-shadow:1px 1px red ">Name : </span><span><%#Eval("Name") %></span></td>
                                </tr>
                            </table>
                        </td>
                        <td style="text-align: right;"></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
