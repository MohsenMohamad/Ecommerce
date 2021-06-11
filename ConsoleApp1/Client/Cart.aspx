<%@ Page Title="" Language="C#" MasterPageFile="~/m1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Client.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style21 {
            width: 149px;
        }
        .auto-style22 {
            width: 427px;
        }
        .auto-style24 {
            margin-left: 585px;
        }
        .auto-style25 {
            width: 228px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="Data_cart" OnItemCommand="DataListCart_ItemCommand1" runat="server" Width="100%" Height="335px" OnSelectedIndexChanged="Data_cart_SelectedIndexChanged1">
                                            <ItemTemplate>
                                                <table align="center" style="width: 100%; border-bottom: 1px solid #CCC">
                                                    <tr>
                                                        <td style="width: 80px;"><span style="font-size: 22px;"><%#Eval("productName")%></span></td>
                                                        <td style="text-align: center; width: 60px;">
                                                        <td style="width: 10px;"></td>
                                                        <td style="width: 302px">
                                                            <table align="left" class="auto-style22">
                                                                <tr>
                                                                    <td style="text-align: left;" class="auto-style21"><span style="font-size: 14px; font-weight: 700;"><%#Eval("nameShop")%></span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left;" class="auto-style21"><span style="font-size: 14px;">Price : <%#Eval("price") %>$</span></td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="auto-style21">
                                                                         <td class="auto-style13">
                                                                            <asp:Label ID="Labelprice1" runat="server" Width="90px" Text="Qty :"></asp:Label>
                                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="img/-.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px" CommandArgument='<%#Eval("productName")+","+Eval("barcode")+","+Eval("nameShop")+","+Eval("Amount")   %>' CommandName="down_command" />
                                                                            <asp:Label ID="Label1"  runat="server" CssClass="td" Height="30px" Text="" Width="54px"><%#Eval("Amount") %></asp:Label>
                                                                        <asp:ImageButton ID="ImageButton2" ImageUrl="img/plus.PNG" runat="server" CssClass="auto-style16" Height="30px" Width="30px"  CommandArgument='<%#Eval("productName")+","+Eval("barcode")+","+Eval("nameShop")+","+Eval("Amount")   %>' CommandName="up_command" />
                                                                            
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("productName")+","+ Eval("descerption")+","+Eval("barcode")+","+Eval("catagory")+","+Eval("price")+","+Eval("nameShop")+","+Eval("Amount")  %>' CommandName="Delete_command" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    <table>
                                        <tr>
                                            <td>

                                                <asp:Label ID="LabelCreditcard" runat="server" Text="enter your credit card number : "></asp:Label>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxCreditcard" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                            <td class="auto-style25" >

                                                <asp:Label ID="Labelerrorcreditcard" runat="server" Text="credit card number is null"></asp:Label>

                                            </td>
                                            <td>

                                                <asp:Label ID="Label3" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                         <tr>
                                            <td>

                                                <asp:Label ID="Labeladdress" runat="server" Text="enter your address : "></asp:Label>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxaddress" runat="server" Height="16px" Width="263px"></asp:TextBox>

                                            </td>
                                             <td class="auto-style25" >

                                                 <asp:Label ID="Labelerroraddress" runat="server" Text="address is null"></asp:Label>

                                             </td>
                                             <td>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                            </td>
                                            <td>

                                            </td>
                                            <td class="auto-style25">

                                            </td>
                                            <td >

                                                <asp:Button ID="Button3" runat="server" Text="Buy Now" Width="79px" CssClass="auto-style24" OnClick="Button3_Click" />

                                            </td>
                                        </tr>
                                    </table>
    </asp:Content>
