<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Client.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="Data_cart" runat="server" Width="100%">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="width: 80px;"><span style="font-size: 22px;">#<%#Eval("productName")%></span></td>
                                                        <td style="text-align: center; width: 60px;">
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                            <table align="left" style="width: 300px">
                                                                <tr>
                                                                    <td style="text-align: left;"><span style="font-size: 14px; font-weight: 700;"><%#Eval("nameShop")%></span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left;"><span style="font-size: 14px;">Price : <%#Eval("price") %>$</span></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="text-align: right;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
    </asp:Content>
