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

                                                                <tr>
                                                                    <td>
                                                                            
                                       <asp:DropDownList ID="DropDownList1"  runat="server" SelectedValue='<%# Eval("Amount") %>'>
                                        <asp:ListItem Enabled="true" Text="Select Amount" Value="-1"></asp:ListItem>
                                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                         <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                         <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                         <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                         <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                         <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                         <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                         <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                         <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                       </asp:DropDownList>

                                                                    </td>
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
